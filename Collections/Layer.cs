using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Brasa;

public sealed class Layer : IDisposable, IEnumerable, IEnumerable<GameObject>
{
	private List<GameObject> m_objects;
	public int Count => m_objects.Count;

	public bool Active;
	public bool Visible;
	public bool Alive;

	public string Name;

	public SamplerState SamplerState = SamplerState.PointWrap;

	public Layer(string name="")
	{
		m_objects = new();
		Name = name;
	}

	public void Added()
	{
		Active = true;
		Visible = true;
		Alive = true;
	}

	public void Removed()
	{
		Active = false;
		Visible = false;
		Alive = false;
	}

	public void Add(GameObject obj) 
	{ 
		m_objects.Add(obj);
		obj.Added();
		obj.Create();
	}
	public bool Remove(GameObject obj) 
	{
		if(!m_objects.Contains(obj)) return false;

		bool v = m_objects.Remove(obj);
		obj.Removed();
		return v;
	}

	public bool Contains(GameObject obj) { return m_objects.Contains(obj); }
	public GameObject Find(Predicate<GameObject> predicate) { return m_objects.Find(predicate); }
	public List<GameObject> FindAll(Predicate<GameObject> predicate) { return m_objects.FindAll(predicate); }
	public T Get<T>() where T : GameObject { return (T)m_objects.Find(obj => obj is T); }
	public List<T> GetAll<T>() where T : GameObject { return m_objects.FindAll(obj => obj is T).OfType<T>().ToList<T>(); }

	public void Clear()
	{
		for(int i=Count-1; i>=0; i--)
		{
			Remove(m_objects[i]);
		}
	}

	public void Destroy()
	{
		List<GameObject> toRemove = new();
		foreach(var obj in m_objects)
		{
			toRemove.Add(obj);
		}

		foreach(var obj in toRemove)
		{
			Remove(obj);
			obj.Dispose();
		}
		toRemove.Clear();
	}

	public void Kill() { m_objects.ForEach(obj => obj.Kill()); Alive = false; }

	public void Update()
	{
		List<GameObject> toRemove = new();

		foreach(var obj in m_objects)
		{
			if(obj.Active && obj.Alive) obj.Update();

			if(obj.ToDestroy) toRemove.Add(obj);
		}

		foreach(var obj in toRemove)
		{
			Remove(obj);
			obj.Dispose();
		}
		toRemove.Clear();
	}

	public void Draw()
	{
		foreach(var obj in m_objects)
		{
			if(obj.Visible && obj.Alive) obj.Draw();
		}
	}

	public void Dispose()
	{
		Destroy();
		GC.SuppressFinalize(this);
	}

    public IEnumerator<GameObject> GetEnumerator()
    {
		return m_objects.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

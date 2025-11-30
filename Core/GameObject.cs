using System;

using Microsoft.Xna.Framework;

namespace Brasa;

public class GameObject : IDisposable
{
	public bool Active;
	public bool Visible;
	public bool Disposed { get; protected set; }
	public bool Alive { get; protected set; }
	public bool ToDestroy { get; protected set; }

	public string Name;

	public Vector2 Position;
	public Vector2 Scale;
	private float m_rotation;
	public virtual float Rotation
	{
		get { return m_rotation; }
		set { m_rotation = value; }
	}

	public Collider Collider;
	public bool Collidable;
	public bool ColliderMove=true;

	public GameObject() : base()
	{
	}

	public GameObject(int x, int y) : base()
	{
		Position = new Vector2(x, y);
	}
	public virtual void Added()
	{
		Active = true;
		Visible = true;
		Alive = true;
	}

	public virtual void Removed()
	{
		Active = false;
		Visible = false;
		Alive = false;
	}

	public virtual void Create()
	{
	}

	public virtual void Update()
	{
		if(Collider != null && ColliderMove) Collider.Position = Position;
	}

	public virtual void Draw()
	{
	}

	public virtual void Kill()
	{
		Alive = false;
	}

	public virtual void Revive()
	{
		Alive = true;
	}

	public virtual void Destroy()
	{
		Kill();
		ToDestroy = true;
	}

	public void AddCollider(Collider col)
	{
		Collider = col;
		Collidable = true;
	}

	public void RemoveCollider()
	{
		Collider = null;
		Collidable = false;
	}

	public bool Collides(GameObject other)
	{
		if(Collidable && other.Collidable && Alive && other.Alive)
		{
			return Collider.Collides(other.Collider);
		}

		return false;
	}

	public virtual void CollisionEnter(GameObject other)
	{
	}


	public void MoveToObject(GameObject other, float speed)
	{
		Vector2 dir = other.Position - Position;

		if(dir.Length() <= speed) { Position = other.Position; return; }

		dir.Normalize();

		Position += dir * speed;
	}

	public float DistanceToObject(GameObject other)
	{
		return (other.Position - Position).Length();
	}

	public void LookAt(GameObject other)
	{
		Vector2 dir = other.Position - Position;
		dir.Normalize();

		Rotation = (float)Math.Atan2(dir.Y, dir.X);
	}

	public void LookAt(Vector2 target)
	{
		Vector2 dir = target - Position;
		dir.Normalize();

		Rotation = (float)Math.Atan2(dir.Y, dir.X);
	}

	public virtual void Dispose()
	{
		if(!Disposed)
		{
			Disposed = true;
			RemoveCollider();
			GC.SuppressFinalize(this);
		}
	}
}

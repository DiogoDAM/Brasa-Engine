using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Brasa;

public class Scene : IDisposable
{
	public bool Active;
	public bool Visible;
	public bool Disposed { get; protected set; }

	public Color BgColor = Color.CornflowerBlue;

	public List<Layer> Layers;

	public SpriteSortMode SortMode = SpriteSortMode.BackToFront;

	public Camera Camera;

	public int Count
	{
		get
		{
			int count = 0;
			foreach(var layer in Layers) count += layer.Count;
			return count;
		}
	}

	public Scene()
	{
		Layers = new();

		Camera = new(Engine.WindowWidth, Engine.WindowHeight);
	}

	public void Add(Layer layer)
	{
		Layers.Add(layer);
		layer.Added();
	}

	public void Remove(Layer layer)
	{
		Layers.Remove(layer);
		layer.Removed();
	}

	public Layer GetLayer(string name)
	{
		return Layers.Find(layer => layer.Name == name);
	}

	public bool TryGetLayer(string name, out Layer layer)
	{
		layer = Layers.Find(layer => layer.Name == name);

		if(layer == null) return false;
		return true;
	}

	public virtual void Added()
	{
		Active = true;
		Visible = true;
	}

	public virtual void Removed()
	{
		Active = false;
		Visible = false;
	}

	public virtual void Create()
	{
	}

	public virtual void Update()
	{
		foreach(var layer in Layers)
		{
			if(layer.Active && layer.Alive) layer.Update();
		}
	}

	public virtual void Draw()
	{
		Engine.GraphicsDevice.Clear(BgColor);

		foreach(var layer in Layers)
		{
			Engine.SpriteBatch.Begin(samplerState: layer.SamplerState, sortMode: SortMode, transformMatrix: Camera.Matrix);

				if(layer.Visible && layer.Alive) layer.Draw();

			Engine.SpriteBatch.End();
		}

	}

	public virtual void Dispose()
	{
		if(!Disposed)
		{
			GC.SuppressFinalize(this);
			Disposed = true;
		}
	}
}

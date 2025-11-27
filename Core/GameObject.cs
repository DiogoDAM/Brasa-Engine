using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace Brasa;

public class GameObject : IDisposable
{
	public bool Active;
	public bool Visible;
	public bool Disposed { get; protected set; }
	public bool Alive { get; protected set; }
	public bool ToDestroy { get; protected set; }

	public Vector2 Position;

	public GameObject()
	{
	}

	public GameObject(int x, int y)
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
	}

	public virtual void Draw()
	{
	}

	public void Kill()
	{
		Alive = false;
	}

	public void Revive()
	{
		Alive = true;
	}

	public void Destroy()
	{
		Kill();
		ToDestroy = true;
	}

	public virtual void Dispose()
	{
		if(!Disposed)
		{
			Disposed = true;
			GC.SuppressFinalize(this);
		}
	}
}

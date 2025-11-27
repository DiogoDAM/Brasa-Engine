using Microsoft.Xna.Framework;

using System;

namespace Brasa;

public abstract class Collider : IDisposable
{
	public Vector2 Position;

	public Collider()
	{
	}

	public bool Collides(Collider col)
	{
		switch(col)
		{
			case BoxCollider box: return Collides(box);
			default: return false;
		}
	}

	public abstract bool Collides(Vector2 vec);
	public abstract bool Collides(BoxCollider other);

	public virtual void Dispose()
	{
	}
}

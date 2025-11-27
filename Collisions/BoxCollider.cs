using Microsoft.Xna.Framework;

using System;

namespace Brasa;

public class BoxCollider : Collider
{
	public int Width;
	public int Height;

	public float Left => Position.X;
	public float Right => Position.X + Width;
	public float Top => Position.Y;
	public float Bottom => Position.Y + Height;

	public BoxCollider(int w, int h) : base()
	{
		Width = w;
		Height = h;
	}

	public override bool Collides(Vector2 vec)
	{
		return CollisionHelper.BoxWithVector2(this, vec);
	}

	public override bool Collides(BoxCollider other)
	{
		return CollisionHelper.BoxWithBox(this, other);
	}
}

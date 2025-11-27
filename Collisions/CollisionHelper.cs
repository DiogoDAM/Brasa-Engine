using System;
using Microsoft.Xna.Framework;

namespace Brasa;

public static class CollisionHelper
{
	public static bool BoxWithBox(BoxCollider b1, BoxCollider b2)
	{
		return b1.Right >= b2.Left &&
			b1.Left <= b2.Right &&
			b1.Bottom >= b2.Top &&
			b1.Top <= b2.Bottom;
	}

	public static bool BoxWithVector2(BoxCollider b, Vector2 v)
	{
		return v.X < b.Right &&
			v.X > b.Left &&
			v.Y < b.Bottom &&
			v.Y > b.Top;
	}

	public static void Overlap(GameObject obj, Layer layer, Action<GameObject, GameObject> resolveCallback)
	{
		foreach(var other in layer)
		{
			if(obj.Collides(other)) resolveCallback.Invoke(obj, other);
		}
	}

	public static void Overlap(Layer layer1, Layer layer2, Action<GameObject, GameObject> resolveCallback)
	{
		foreach(var obj in layer1)
		{
			foreach(var other in layer2)
			{
				if(obj.Collides(other)) resolveCallback.Invoke(obj, other);
			}
		}
	}
}

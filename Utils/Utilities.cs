using Microsoft.Xna.Framework;

using System;

namespace Brasa;

public static class Utilities
{
	private static Random m_random = new();

	public static int Random(int min, int max)
	{
		return m_random.Next(min, max);
	}

	public static float Random(float min, float max)
	{
		return ((((float)m_random.NextDouble()) * (max - min) + min));
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

	public static void Collides(GameObject obj, Layer layer)
	{
		foreach(var other in layer)
		{
				if(obj.Collides(other)) { obj.CollisionEnter(other); other.CollisionEnter(obj); }
		}
	}

	public static void Collides(Layer layer1, Layer layer2)
	{
		foreach(var obj in layer1)
		{
			foreach(var other in layer2)
			{
				if(obj.Collides(other)) { obj.CollisionEnter(other); other.CollisionEnter(obj); }
			}
		}
	}

}

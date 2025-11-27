using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brasa;

public sealed class TextureRegion
{
	public Rectangle Bounds;
	public Texture2D Texture;

	public TextureRegion(Texture2D texture, int x, int y, int w, int h)
	{
		Texture = texture;
		Bounds = new(x, y, w, h);
	}

	public TextureRegion(Texture2D texture, int w, int h)
	{
		Texture = texture;
		Bounds = new(0, 0, w, h);
	}
}

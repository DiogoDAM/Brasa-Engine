using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brasa;

public class Sprite
{
	public TextureRegion Region;
	public Color Color = Color.White;
	public SpriteEffects Flip;
	public Vector2 Origin;
	public Vector2 Position;
	public float Rotation = 0f;
	public Vector2 Scale = Vector2.One;
	public float Depth = 0f;

	public int Width
	{
		get { return Region.Bounds.Width; }
		set { Region.Bounds.Width = value; }
	}

	public int Height 
	{
		get { return Region.Bounds.Height; }
		set { Region.Bounds.Height = value; }
	}

	public Sprite(string texturePath, int x, int y, int w, int h)
	{
		Region = new(Engine.Assets.GetTexture(texturePath), x, y, w, h);
	}

	public Sprite(string texturePath, int w, int h)
	{
		Region = new(Engine.Assets.GetTexture(texturePath), 0, 0, w, h);
	}

	public Sprite(Texture2D texture, int x, int y, int w, int h)
	{
		Region = new(texture, x, y, w, h);
	}

	public Sprite(Texture2D texture, int w, int h)
	{
		Region = new(texture, 0, 0, w, h);
	}


	public void CenterOrigin()
	{
		Origin.X = Width * 0.5f;
		Origin.Y = Height * 0.5f;
	}

	public void FlipH()
	{
		Flip = (Flip == SpriteEffects.None) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
	}

	public void FlipV()
	{
		Flip = (Flip == SpriteEffects.None) ? SpriteEffects.FlipVertically : SpriteEffects.None;
	}

	public void Draw()
	{
		Engine.SpriteBatch.Draw(Region.Texture, Position, Region.Bounds, Color, Rotation, Origin, Scale, Flip, Depth);
	}
}

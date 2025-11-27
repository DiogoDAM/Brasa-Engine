using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brasa;

public class SpriteText
{
	public SpriteFont Font;
	public string Text;
	public Color Color = Color.White;
	public SpriteEffects Flip;
	public Vector2 Origin;
	public Vector2 Position;
	public float Rotation = 0f;
	public Vector2 Scale = Vector2.One;
	public float Depth = 0f;

	public int Width
	{
		get { return (int)Font.MeasureString(Text).X; }
	}

	public int Height 
	{
		get { return (int)Font.MeasureString(Text).Y; }
	}

	public SpriteText(string fontPath, string text)
	{
		Font = Engine.Assets.GetFont(fontPath);
		Text = text;
	}

	public SpriteText(string fontPath)
	{
		Font = Engine.Assets.GetFont(fontPath);
	}

	public SpriteText(SpriteFont font, string text)
	{
		Font = font;
		Text = text;
	}

	public SpriteText(SpriteFont font)
	{
		Font = font;
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
		Engine.SpriteBatch.DrawString(Font, Text, Position, Color, Rotation, Origin, Scale, Flip, Depth);
	}
}

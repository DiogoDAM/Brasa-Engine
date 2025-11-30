using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

namespace Brasa;

public class Entity : GameObject
{
	public Sprite Sprite;


	public int Width
	{
		get { return Sprite.Width; }
		set { Sprite.Width = value; }
	}

	public int Height 
	{
		get { return Sprite.Height; }
		set { Sprite.Height = value; }
	}

	public override float Rotation
	{
		get { return Sprite.Rotation; }
		set { Sprite.Rotation = value; }
	}

	public Color Color
	{
		get { return Sprite.Color; }
		set { Sprite.Color = value; }
	}

	public Entity() : base()
	{
	}

	public Entity(int x, int y) : base(x, y)
	{
	}

	public override void Update()
	{
		base.Update();

		Sprite.Position = Position;
	}

	public override void Draw()
	{
		base.Draw();

		Sprite.Draw();
	}

	public void MakeGraphic(int w, int h, Color color)
	{
		Texture2D texture = new Texture2D(Engine.GraphicsDevice, w, h);
		Color[] data = new Color[w * h];

		for(int y=0; y<h; y++)
		{
			for(int x=0; x<w; x++)
			{
				data[x + y * w] = color;
			}
		}

		texture.SetData(data);
		Sprite = new(texture, w, h);
	}

	public void LoadGraphic(string texturePath, int w, int h)
	{
		Sprite = new(texturePath, w, h);
	}

	public void CenterOrigin() { Sprite.CenterOrigin(); }



	public override void Dispose()
	{
		if(!Disposed)
		{
			Sprite = null;
			Disposed = true;
			GC.SuppressFinalize(this);
		}
	}
}

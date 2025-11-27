using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Brasa;

public class Camera
{
	public Vector2 Position;
	public Vector2 Scale = Vector2.One;
	public float Rotation;

	public Viewport Viewport;

	public Matrix Matrix => Matrix.CreateTranslation(-Position.X, -Position.Y, 0f) *
		Matrix.CreateRotationZ(Rotation) *
		Matrix.CreateScale(Scale.X, Scale.Y, 1f);

	public Vector2 CursorPosition => Vector2.Transform(Engine.Input.Mouse.CursorPosition, Matrix.Invert(Matrix));

	public Camera(int w, int h)
	{
		Viewport = new();
		Viewport.Width = w;
		Viewport.Height = h;
	}
}

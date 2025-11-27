using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Brasa;

public class Engine : Game
{
	public static GraphicsDeviceManager Graphics;
	public static new GraphicsDevice GraphicsDevice;
	public static new ContentManager Content;
	public static SpriteBatch SpriteBatch;

	public static Time Time;

	public static Input Input;

	public static Scene ActiveScene;

	public static AssetsManager Assets;

	public static int WindowWidth => Graphics.PreferredBackBufferWidth;
	public static int WindowHeight => Graphics.PreferredBackBufferHeight;

	public Engine(int ww, int wh, string title, bool fullscreen) : base()
	{
		Graphics = new(this);

		Content = base.Content;
		Content.RootDirectory = "Content";

		SetWindowSize(ww, wh);
		Window.Title = title;
		SetWindowFullScreen(fullscreen);

		Time = new();

		Input = new();

		ActiveScene = new();

		Assets = new();

		IsMouseVisible = true;
	}

    protected override void Initialize()
    {
		GraphicsDevice = base.GraphicsDevice;
		SpriteBatch = new SpriteBatch(GraphicsDevice);

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
		Time.DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
		Input.Update();

        base.Update(gameTime);

		ActiveScene.Update();
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);

		ActiveScene.Draw();
    }

	public static void SetWindowSize(int ww, int wh)
	{
		Graphics.PreferredBackBufferWidth = ww;
		Graphics.PreferredBackBufferHeight = wh;
		Graphics.ApplyChanges();
	}

	public static void SetWindowFullScreen(bool value)
	{
		Graphics.IsFullScreen = value;
		Graphics.ApplyChanges();
	}

	public static void ToggleFullScreen()
	{
		Graphics.ToggleFullScreen();
		Graphics.ApplyChanges();
	}


	public void ChangeScene(Scene scene)
	{
		ActiveScene?.Removed();
		ActiveScene = scene;
		ActiveScene.Added();
		ActiveScene.Create();
	}
}

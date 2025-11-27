using Brasa.Inputs;

namespace Brasa;

public sealed class Input
{
	public KeyboardManager Keyboard { get; private set; }
	public MouseManager Mouse { get; private set; }

	public Input()
	{
		Keyboard = new();
		Mouse = new();
	}

	public void Update()
	{
		Keyboard.Update();
		Mouse.Update();
	}
}

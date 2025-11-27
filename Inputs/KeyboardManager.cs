using Microsoft.Xna.Framework.Input;

namespace Brasa.Inputs;

public class KeyboardManager
{
	private KeyboardState _prev;
	private KeyboardState _curr;

	public KeyboardManager()
	{
		_prev = Keyboard.GetState();
		_curr = Keyboard.GetState();
	}

	public void Update()
	{
		_prev = _curr;
		_curr = Keyboard.GetState();
	}

	public bool KeyDown(Keys key)
	{
		return _curr.IsKeyDown(key);
	}

	public bool KeyUp(Keys key)
	{
		return _curr.IsKeyUp(key);
	}

	public bool KeyPressed(Keys key)
	{
		return _curr.IsKeyDown(key) && _prev.IsKeyUp(key);
	}

	public bool KeyReleased(Keys key)
	{
		return _curr.IsKeyUp(key) && _prev.IsKeyDown(key);
	}
}

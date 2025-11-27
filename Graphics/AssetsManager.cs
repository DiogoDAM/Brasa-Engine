using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace Brasa;

public sealed class AssetsManager
{
	private Dictionary<string, Texture2D> m_textures;
	private Dictionary<string, SpriteFont> m_fonts;

	public string TexturePath = "Textures/";
	public string FontPath = "Fonts/";

	public AssetsManager()
	{
		m_textures = new();
		m_fonts = new();
	}

	public void LoadTexture(string path)
	{
		Texture2D texture = Engine.Content.Load<Texture2D>(TexturePath + path);
		m_textures.Add(path, texture);
	}

	public Texture2D GetTexture(string name)
	{
		if(!m_textures.ContainsKey(name)) throw new KeyNotFoundException("AssetsManager.GetTexture() don't has a texture named: " + name);
		return m_textures[name];
	}

	public void LoadFont(string path)
	{
		SpriteFont font = Engine.Content.Load<SpriteFont>(FontPath + path);
		m_fonts.Add(path, font);
	}

	public SpriteFont GetFont(string name)
	{
		if(!m_fonts.ContainsKey(name)) throw new KeyNotFoundException("AssetsManager.GetFonts() don't has a font named: " + name);
		return m_fonts[name];
	}
}

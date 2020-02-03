using System;
using System.Collections.Generic;
using System.Linq;

namespace TextureComposer
{
	public class ColorChannel
	{
		private byte[] _data;
		public int Width { get; }
		public int Height { get; }
		private List<Func<byte, byte>> _modifs = new List<Func<byte, byte>>();
		
		public byte this[int x, int y]
		{
			get => _data[x + y * Width];
			set => _data[x + y * Width] = value;
		}

		public int Length => _data.Length;
		
		private ColorChannel(byte[] data, int width, int height, List<Func<byte, byte>> modifs)
		{
			_data = data;
			Width = width;
			Height = height;
			_modifs = modifs;
		}

		public ColorChannel(int width, int height, byte[] data)
		{
			_data = data;
			Width = width;
			Height = height;
		}
		
		public ColorChannel(int width, int height)
		{
			_data = new byte[width * height];
			Width = width;
			Height = height;
		}
		
		public ColorChannel(int width, int height, byte initialValue)
		{
			_data = Enumerable.Repeat(initialValue, width * height).ToArray();
			Width = width;
			Height = height;
		}

		public byte TransformedByte(int i)
		{
			byte b = _data[i];
			_modifs.ForEach(modif => b = modif.Invoke(b));
			return b;
		}
		
		public byte TransformedByte(int x, int y)
		{
			return TransformedByte(x + y * Width);
		}

		public ColorChannel AddModif(Func<byte, byte> newModif)
		{
			List<Func<byte, byte>> modifs = new List<Func<byte, byte>>();
			
			_modifs.ForEach(modif => modifs.Add((Func<byte, byte>)modif.Clone()));
			
			modifs.Add(newModif);
			
			return new ColorChannel(_data, Width, Height, modifs);
		}
	}
}
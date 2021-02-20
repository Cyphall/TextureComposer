using System;
using System.Collections.Generic;
using System.Linq;

namespace TextureComposer
{
	public class ColorChannel
	{
		private byte[] _data;
		private List<Action<byte[]>> _modifiers = new();
		
		public byte this[int x, int y]
		{
			get => _data[x + y * Width];
			set => _data[x + y * Width] = value;
		}

		public int Width { get; }
		public int Height { get; }
		public int Length => _data.Length;

		public byte[,] FinalData
		{
			get
			{
				byte[] tempData = new byte[Length];
				Buffer.BlockCopy(_data, 0, tempData, 0, Length);
				
				_modifiers.ForEach(modif => modif.Invoke(tempData));
				
				byte[,] finalData = new byte[Width, Height];
				
				for (int y = 0; y < Height; y++)
				{
					for (int x = 0; x < Width; x++)
					{
						finalData[x, y] = tempData[x + y * Width];
					}
				}

				return finalData;
			}
		}
		
		private ColorChannel(byte[] data, int width, int height, List<Action<byte[]>> modifiers)
		{
			_data = data;
			Width = width;
			Height = height;
			_modifiers = modifiers;
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

		public ColorChannel AddModifier(Action<byte[]> newModifier)
		{
			List<Action<byte[]>> modifiers = new();
			
			_modifiers.ForEach(modifier => modifiers.Add((Action<byte[]>)modifier.Clone()));
			
			modifiers.Add(newModifier);
			
			return new ColorChannel(_data, Width, Height, modifiers);
		}
	}
}
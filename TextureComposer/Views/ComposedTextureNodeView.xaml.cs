using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows;
using Microsoft.Win32;
using ReactiveUI;

namespace TextureComposer.Views
{
	public partial class ComposedTextureNodeView : IViewFor<ComposedTextureNodeViewModel>
	{
		#region ViewModel

		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
			typeof(ComposedTextureNodeViewModel), typeof(ComposedTextureNodeView));

		public ComposedTextureNodeViewModel ViewModel
		{
			get => (ComposedTextureNodeViewModel) GetValue(ViewModelProperty);
			set => SetValue(ViewModelProperty, value);
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (ComposedTextureNodeViewModel) value;
		}

		#endregion

		public ComposedTextureNodeView()
		{
			InitializeComponent();

			this.WhenActivated(d => { this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d); });
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			ColorChannel r = ViewModel.InR.Value;
			ColorChannel g = ViewModel.InG.Value;
			ColorChannel b = ViewModel.InB.Value;
			ColorChannel a = ViewModel.InA.Value;

			
			// Ensure that at least 1 channel is connected and all connected channels all have the same size
			int width = -1;
			int height = -1;

			if (r != null)
			{
				if (width == -1)
				{
					width = r.Width;
					height = r.Height;
				}
			}
			if (g != null)
			{
				if (width == -1)
				{
					width = g.Width;
					height = g.Height;
				}
				else if (g.Width != width || g.Height != height)
				{
					Console.WriteLine("All channels are not the same size");
					return;
				}
			}
			if (b != null)
			{
				if (width == -1)
				{
					width = b.Width;
					height = b.Height;
				}
				else if (b.Width != width || b.Height != height)
				{
					Console.WriteLine("All channels are not the same size");
					return;
				}
			}
			if (a != null)
			{
				if (width == -1)
				{
					width = a.Width;
					height = a.Height;
				}
				else if (a.Width != width || a.Height != height)
				{
					Console.WriteLine("All channels are not the same size");
					return;
				}
			}

			if (width == -1 || height == -1)
			{
				Console.WriteLine("None of the channels are defined");
				return;
			}
			
			
			// Generate the Save File dialog
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				InitialDirectory = @"C:\Users\Cyphall\Downloads\",
				Filter = "png file (*.png)|*.png|jpeg file (*.jpg)|*.jpg",
				FileName = "output",
				RestoreDirectory = true
			};

			if (saveFileDialog.ShowDialog() != true) return;

			
			// Convert the connected ColorChannels to an image for saving
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					bitmap.SetPixel(x, y, Color.FromArgb(
						a?.TransformedByte(x, y) ?? 255,
						r?.TransformedByte(x, y) ?? 0,
						g?.TransformedByte(x, y) ?? 0,
						b?.TransformedByte(x, y) ?? 0
					));
				}
			}

			
			// Save the image with the desired format
			switch (saveFileDialog.FilterIndex)
			{
				case 1: // PNG
				{
					ImageFormat format = ImageFormat.Png;
					
					bitmap.Save(saveFileDialog.FileName, format);
				}break;
				case 2: // JPG
				{
					ImageFormat format = ImageFormat.Jpeg;
					
					ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().First(info => info.FormatID == format.Guid);

					EncoderParameters parameters = new EncoderParameters
					{
						Param =
						{
							[0] = new EncoderParameter(Encoder.Quality, 95L)
						}
					};
					
					bitmap.Save(saveFileDialog.FileName, codec, parameters);
				}break;
				default:
					throw new Exception();
			}
		}
	}
}
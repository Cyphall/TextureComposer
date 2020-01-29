using System.Drawing;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using Microsoft.Win32;
using ReactiveUI;
using Color = System.Drawing.Color;

namespace TextureComposer.Views
{
	public partial class TextureNodeView : IViewFor<TextureNode>
	{
		#region ViewModel
		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
			typeof(TextureNode), typeof(TextureNodeView));

		public TextureNode ViewModel
		{
			get => (TextureNode)GetValue(ViewModelProperty);
			set => SetValue(ViewModelProperty, value);
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (TextureNode)value;
		}
		#endregion
		
		public TextureNodeView()
		{
			InitializeComponent();
			
			this.WhenActivated(d =>
			{
				this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
			});
		}
		
		private void BrowseButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog
			{
				InitialDirectory = @"c:\",
				Filter = "Image files (*.png, *.jpg)|*.png;*.jpg;*.jpeg",
				RestoreDirectory = true
			};

			if (dlg.ShowDialog() != true) return;
			
			Bitmap image = new Bitmap(dlg.FileName);

			byte[,] r = new byte[image.Width, image.Height];
			byte[,] g = new byte[image.Width, image.Height];
			byte[,] b = new byte[image.Width, image.Height];
			byte[,] a = new byte[image.Width, image.Height];
				
			for (int y = 0; y < image.Height; y++)
			{
				for (int x = 0; x < image.Width; x++)
				{
					Color color = image.GetPixel(x, y);

					r[x, y] = color.R;
					g[x, y] = color.G;
					b[x, y] = color.B;
					a[x, y] = color.A;
				}
			}

			ViewModel.OutR.Value = Observable.Return(r);
			ViewModel.OutG.Value = Observable.Return(g);
			ViewModel.OutB.Value = Observable.Return(b);
			ViewModel.OutA.Value = Observable.Return(a);
		}
	}
}
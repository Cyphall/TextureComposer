using System.Drawing;
using System.IO;
using System.Reactive.Disposables;
using System.Windows;
using Microsoft.Win32;
using ReactiveUI;
using TextureComposer.ViewModels.Nodes;

namespace TextureComposer.Views
{
	public partial class TextureNodeView : IViewFor<TextureNodeViewModel>
	{
		#region ViewModel
		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
			typeof(TextureNodeViewModel), typeof(TextureNodeView));

		public TextureNodeViewModel ViewModel
		{
			get => (TextureNodeViewModel)GetValue(ViewModelProperty);
			set => SetValue(ViewModelProperty, value);
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (TextureNodeViewModel)value;
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
				Filter = "Image files (*.png, *.jpg)|*.png;*.jpg;*.jpeg",
				RestoreDirectory = true
			};

			if (dlg.ShowDialog() != true) return;

			ViewModel.Name = Path.GetFileName(dlg.FileName);
			
			Bitmap image = new Bitmap(dlg.FileName);
			
			int height = image.Height;
			int width = image.Width;

			ColorChannel r = new ColorChannel(width, height);
			ColorChannel g = new ColorChannel(width, height);
			ColorChannel b = new ColorChannel(width, height);
			ColorChannel a = new ColorChannel(width, height);

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Color color = image.GetPixel(x, y);

					r[x, y] = color.R;
					g[x, y] = color.G;
					b[x, y] = color.B;
					a[x, y] = color.A;
				}
			}

			ViewModel.R.Value = r;
			ViewModel.G.Value = g;
			ViewModel.B.Value = b;
			ViewModel.A.Value = a;
			ViewModel.TextureSize.Value = new Size(width, height);
		}
	}
}
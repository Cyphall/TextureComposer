using System;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using ReactiveUI;

namespace TextureComposer.Views
{
	public partial class TextureNodeView : UserControl, IViewFor<TextureNode>
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
		
		public ImageSource TestImageSource;
		
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

			if (dlg.ShowDialog() == true)
			{
				BitmapImage image = new BitmapImage(new Uri(dlg.FileName));
				TestImageSource = image;
			}
		}
	}
}
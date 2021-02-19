using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;
using TextureComposer.ViewModels;

namespace TextureComposer.Views
{
	public partial class MainWindow : IViewFor<MainViewModel>
	{
		#region ViewModel
		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
			typeof(MainViewModel), typeof(MainWindow), new PropertyMetadata(null));

		public MainViewModel ViewModel
		{
			get => (MainViewModel)GetValue(ViewModelProperty);
			set => SetValue(ViewModelProperty, value);
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (MainViewModel)value;
		}
		#endregion
		
		public MainWindow()
		{
			InitializeComponent();

			ViewModel = new MainViewModel();

			this.WhenActivated(d =>
			{
				this.OneWayBind(ViewModel, vm => vm.ListViewModel, v => v.NodeList.ViewModel).DisposeWith(d);
				this.OneWayBind(ViewModel, vm => vm.NetworkViewModel, v => v.NetworkView.ViewModel).DisposeWith(d);
			});
		}
	}
}
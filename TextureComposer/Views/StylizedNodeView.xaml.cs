using System.Reactive.Disposables;
using System.Windows;
using NodeNetwork.ViewModels;
using ReactiveUI;

namespace TextureComposer.Views
{
	public partial class StylizedNodeView : IViewFor<NodeViewModel>
	{
		#region ViewModel
		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
			typeof(NodeViewModel), typeof(StylizedNodeView));

		public NodeViewModel ViewModel
		{
			get => (NodeViewModel)GetValue(ViewModelProperty);
			set => SetValue(ViewModelProperty, value);
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (NodeViewModel)value;
		}
		#endregion
		
		public StylizedNodeView()
		{
			InitializeComponent();
			
			this.WhenActivated(d =>
			{
				this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
			});
		}
	}
}
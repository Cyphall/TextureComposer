using System;
using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;

namespace TextureComposer.Views
{
	public partial class ComposedTextureNodeView : IViewFor<ComposedTextureNode>
	{
		#region ViewModel
		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
			typeof(ComposedTextureNode), typeof(ComposedTextureNodeView));

		public ComposedTextureNode ViewModel
		{
			get => (ComposedTextureNode)GetValue(ViewModelProperty);
			set => SetValue(ViewModelProperty, value);
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (ComposedTextureNode)value;
		}
		#endregion
		
		public ComposedTextureNodeView()
		{
			InitializeComponent();
			
			this.WhenActivated(d =>
			{
				this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
			});
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			if (ViewModel.InR.Value != null) Console.WriteLine($"R: {ViewModel.InR.Value.GetLength(0)}x{ViewModel.InR.Value.GetLength(1)}");
			if (ViewModel.InG.Value != null) Console.WriteLine($"G: {ViewModel.InG.Value.GetLength(0)}x{ViewModel.InG.Value.GetLength(1)}");
			if (ViewModel.InB.Value != null) Console.WriteLine($"B: {ViewModel.InB.Value.GetLength(0)}x{ViewModel.InB.Value.GetLength(1)}");
			if (ViewModel.InA.Value != null) Console.WriteLine($"A: {ViewModel.InA.Value.GetLength(0)}x{ViewModel.InA.Value.GetLength(1)}");
		}
	}
}
using System.Windows;
using ReactiveUI;
using TextureComposer.ViewModels;

namespace TextureComposer.Views
{
	public partial class ByteValueEditorView : IViewFor<ByteValueEditorViewModel>
	{
		#region ViewModel
		public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
			typeof(ByteValueEditorViewModel), typeof(ByteValueEditorView), new PropertyMetadata(null));

		public ByteValueEditorViewModel ViewModel
		{
			get => (ByteValueEditorViewModel)GetValue(ViewModelProperty);
			set => SetValue(ViewModelProperty, value);
		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (ByteValueEditorViewModel)value;
		}
		#endregion
        
		public ByteValueEditorView()
		{
			InitializeComponent();

			this.WhenActivated(d => d(
				this.Bind(ViewModel, vm => vm.Value, v => v.ValueUpDown.Value)
			));
		}
	}
}
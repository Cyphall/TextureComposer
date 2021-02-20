using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using Splat;
using TextureComposer.Views;

namespace TextureComposer.ViewModels
{
	public class ByteValueEditorViewModel : ValueEditorViewModel<byte>
	{
		static ByteValueEditorViewModel()
		{
			Locator.CurrentMutable.Register(() => new ByteValueEditorView(), typeof(IViewFor<ByteValueEditorViewModel>));
		}

		public ByteValueEditorViewModel()
		{
			Value = 0;
		}
	}
}
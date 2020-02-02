using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using TextureComposer.Views;

namespace TextureComposer
{
	public class ByteValueEditorViewModel : ValueEditorViewModel<byte?>
	{
		static ByteValueEditorViewModel()
		{
			Splat.Locator.CurrentMutable.Register(() => new ByteValueEditorView(), typeof(IViewFor<ByteValueEditorViewModel>));
		}

		public ByteValueEditorViewModel()
		{
			Value = 0;
		}
	}
}
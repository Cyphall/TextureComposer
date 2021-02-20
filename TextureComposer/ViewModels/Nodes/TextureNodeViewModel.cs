using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;
using TextureComposer.Views;

namespace TextureComposer.ViewModels.Nodes
{
	public class TextureNodeViewModel : NodeViewModel
	{
		public ValueEditorViewModel<ColorChannel> R = new ValueEditorViewModel<ColorChannel>();
		public ValueEditorViewModel<ColorChannel> G = new ValueEditorViewModel<ColorChannel>();
		public ValueEditorViewModel<ColorChannel> B = new ValueEditorViewModel<ColorChannel>();
		public ValueEditorViewModel<ColorChannel> A = new ValueEditorViewModel<ColorChannel>();
		public ValueEditorViewModel<Size> TextureSize = new ValueEditorViewModel<Size>();
		
		public ValueNodeOutputViewModel<ColorChannel> OutR { get; } = new ValueNodeOutputViewModel<ColorChannel>();
		public ValueNodeOutputViewModel<ColorChannel> OutG { get; } = new ValueNodeOutputViewModel<ColorChannel>();
		public ValueNodeOutputViewModel<ColorChannel> OutB { get; } = new ValueNodeOutputViewModel<ColorChannel>();
		public ValueNodeOutputViewModel<ColorChannel> OutA { get; } = new ValueNodeOutputViewModel<ColorChannel>();
		
		public ValueNodeOutputViewModel<Size> OutTextureSize { get; } = new ValueNodeOutputViewModel<Size>();
		
		public TextureNodeViewModel()
		{
			Name = "Texture";
			
			OutR.Name = "R";
			OutR.Value = this.WhenAnyValue(vm => vm.R.Value);
			Outputs.Add(OutR);
			
			OutG.Name = "G";
			OutG.Value = this.WhenAnyValue(vm => vm.G.Value);
			Outputs.Add(OutG);
			
			OutB.Name = "B";
			OutB.Value = this.WhenAnyValue(vm => vm.B.Value);
			Outputs.Add(OutB);
			
			OutA.Name = "A";
			OutA.Value = this.WhenAnyValue(vm => vm.A.Value);
			Outputs.Add(OutA);

			OutTextureSize.Name = "Size";
			OutTextureSize.Value = this.WhenAnyValue(vm => vm.TextureSize.Value);
			Outputs.Add(OutTextureSize);
		}
		
		static TextureNodeViewModel()
		{
			Locator.CurrentMutable.Register(() => new TextureNodeView(), typeof(IViewFor<TextureNodeViewModel>));
		}
	}
}
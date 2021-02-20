using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;
using TextureComposer.DataStructures;
using TextureComposer.Views;

namespace TextureComposer.ViewModels.Nodes
{
	public class TextureNodeViewModel : NodeViewModel
	{
		public ValueEditorViewModel<ColorChannel> R = new();
		public ValueEditorViewModel<ColorChannel> G = new();
		public ValueEditorViewModel<ColorChannel> B = new();
		public ValueEditorViewModel<ColorChannel> A = new();
		public ValueEditorViewModel<Size> TextureSize = new();
		
		public ValueNodeOutputViewModel<ColorChannel> OutR { get; } = new();
		public ValueNodeOutputViewModel<ColorChannel> OutG { get; } = new();
		public ValueNodeOutputViewModel<ColorChannel> OutB { get; } = new();
		public ValueNodeOutputViewModel<ColorChannel> OutA { get; } = new();
		
		public ValueNodeOutputViewModel<Size> OutTextureSize { get; } = new();
		
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
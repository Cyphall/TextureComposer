using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;
using TextureComposer.Views;

namespace TextureComposer.ViewModels.Nodes
{
	public class ComposedTextureNodeViewModel : NodeViewModel
	{
		public ValueNodeInputViewModel<ColorChannel> InR { get; } = new ValueNodeInputViewModel<ColorChannel>();
		public ValueNodeInputViewModel<ColorChannel> InG { get; } = new ValueNodeInputViewModel<ColorChannel>();
		public ValueNodeInputViewModel<ColorChannel> InB { get; } = new ValueNodeInputViewModel<ColorChannel>();
		public ValueNodeInputViewModel<ColorChannel> InA { get; } = new ValueNodeInputViewModel<ColorChannel>();
		
		public ComposedTextureNodeViewModel()
		{
			Name = "Composed Texture";
			
			InR.Name = "R";
			Inputs.Add(InR);
			
			InG.Name = "G";
			Inputs.Add(InG);
			
			InB.Name = "B";
			Inputs.Add(InB);
			
			InA.Name = "A";
			Inputs.Add(InA);
		}
		
		static ComposedTextureNodeViewModel()
		{
			Locator.CurrentMutable.Register(() => new ComposedTextureNodeView(), typeof(IViewFor<ComposedTextureNodeViewModel>));
		}
	}
}
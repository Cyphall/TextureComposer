using System.Reactive.Linq;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using TextureComposer.Views;

namespace TextureComposer
{
	public class TextureNode : NodeViewModel
	{
		public ValueNodeOutputViewModel<byte[,]> OutR { get; } = new ValueNodeOutputViewModel<byte[,]>();
		public ValueNodeOutputViewModel<byte[,]> OutG { get; } = new ValueNodeOutputViewModel<byte[,]>();
		public ValueNodeOutputViewModel<byte[,]> OutB { get; } = new ValueNodeOutputViewModel<byte[,]>();
		public ValueNodeOutputViewModel<byte[,]> OutA { get; } = new ValueNodeOutputViewModel<byte[,]>();
		
		public TextureNode()
		{
			Name = "Texture";
			
			OutR.Name = "R";
			Outputs.Add(OutR);
			
			OutG.Name = "G";
			Outputs.Add(OutG);
			
			OutB.Name = "B";
			Outputs.Add(OutB);
			
			OutA.Name = "A";
			Outputs.Add(OutA);
			
			OutR.Value = Observable.Return(new byte[10,10]);
			OutG.Value = Observable.Return(new byte[10,10]);
			OutB.Value = Observable.Return(new byte[10,10]);
			OutA.Value = Observable.Return(new byte[10,10]);
		}
		
		static TextureNode()
		{
			Splat.Locator.CurrentMutable.Register(() => new TextureNodeView(), typeof(IViewFor<TextureNode>));
		}
	}
}
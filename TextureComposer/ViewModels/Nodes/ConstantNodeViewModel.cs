using System.Reactive.Linq;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;
using TextureComposer.Views;

namespace TextureComposer.ViewModels.Nodes
{
	public class ConstantNodeViewModel : NodeViewModel
	{
		public ByteValueEditorViewModel Color = new();
		
		public ValueNodeInputViewModel<Size> In { get; } = new();
		
		public ValueNodeOutputViewModel<ColorChannel> Out { get; } = new();
		
		public ConstantNodeViewModel()
		{
			Name = "Constant Color";

			In.Name = "Size";
			Inputs.Add(In);
			
			Out.Name = "Channel";
			Out.Editor = Color;
			Out.Value = this.WhenAnyValue(vm => vm.In.Value, vm => vm.Color.Value)
				.Select(
					data => data.Item1 != null ? new ColorChannel(data.Item1.X, data.Item1.Y, data.Item2) : null
				);
			Outputs.Add(Out);
		}
		
		static ConstantNodeViewModel()
		{
			Locator.CurrentMutable.Register(() => new StylizedNodeView(), typeof(IViewFor<ConstantNodeViewModel>));
		}
	}
}
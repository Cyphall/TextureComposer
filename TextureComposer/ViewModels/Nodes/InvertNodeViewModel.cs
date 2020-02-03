using System.Reactive.Linq;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;
using TextureComposer.Views;

namespace TextureComposer
{
	public class InvertNodeViewModel : NodeViewModel
	{
		public ValueNodeInputViewModel<ColorChannel> In { get; } = new ValueNodeInputViewModel<ColorChannel>();
		
		public ValueNodeOutputViewModel<ColorChannel> Out { get; } = new ValueNodeOutputViewModel<ColorChannel>();
		
		public InvertNodeViewModel()
		{
			Name = "Invert Color";
			
			In.Name = "Channel";
			Inputs.Add(In);
			
			Out.Name = "Channel";
			Out.Value = this.WhenAnyValue(vm => vm.In.Value)
				.Select(
					_ => In.Value?.AddModif(
						b => (byte) (byte.MaxValue - b)
						)
					);
			Outputs.Add(Out);
		}
		
		static InvertNodeViewModel()
		{
			Locator.CurrentMutable.Register(() => new StylizedNodeView(), typeof(IViewFor<InvertNodeViewModel>));
		}
	}
}
using System.Reactive.Linq;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;
using TextureComposer.Views;

namespace TextureComposer
{
	public class ExtractSizeNodeViewModel : NodeViewModel
	{
		public ValueNodeInputViewModel<ColorChannel> In { get; } = new ValueNodeInputViewModel<ColorChannel>();
		
		public ValueNodeOutputViewModel<Size> Out { get; } = new ValueNodeOutputViewModel<Size>();
		
		public ExtractSizeNodeViewModel()
		{
			Name = "Extract Size";
			
			In.Name = "Channel";
			Inputs.Add(In);
			
			Out.Name = "Size";
			Out.Value = this.WhenAnyValue(vm => vm.In.Value)
				.Select(
					_ => In.Value != null ? new Size(In.Value.Width, In.Value.Height) : null
					);
			Outputs.Add(Out);
		}
		
		static ExtractSizeNodeViewModel()
		{
			Locator.CurrentMutable.Register(() => new StylizedNodeView(), typeof(IViewFor<ExtractSizeNodeViewModel>));
		}
	}
}
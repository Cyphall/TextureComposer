using System.Reactive.Linq;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;
using TextureComposer.Views;

namespace TextureComposer
{
	public class ConstantNodeViewModel : NodeViewModel
	{
		public ByteValueEditorViewModel Color = new ByteValueEditorViewModel();
		
		public ValueNodeInputViewModel<Size> In { get; } = new ValueNodeInputViewModel<Size>();
		
		public ValueNodeOutputViewModel<ColorChannel> Out { get; } = new ValueNodeOutputViewModel<ColorChannel>();
		
		public ConstantNodeViewModel()
		{
			Name = "Constant Color";

			In.Name = "Size";
			Inputs.Add(In);
			
			Out.Name = "Channel";
			Out.Editor = Color;
			Out.Value = this.WhenAnyValue(vm => vm.In.Value)
				.Select(
					_ => In.Value != null ? new ColorChannel(In.Value.X, In.Value.Y, Color.Value.GetValueOrDefault(0)) : null
				);
			Outputs.Add(Out);
		}
		
		static ConstantNodeViewModel()
		{
			Locator.CurrentMutable.Register(() => new StylizedNodeView(), typeof(IViewFor<ConstantNodeViewModel>));
		}
	}
}
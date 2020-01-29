using System.Reactive.Linq;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace TextureComposer
{
	public class OutputTestNode : NodeViewModel
	{
		public ValueNodeOutputViewModel<byte?> OutValue { get; }

		public OutputTestNode()
		{
			Name = "Test Output";

			OutValue = new ValueNodeOutputViewModel<byte?>
			{
				Name = "Output Value"
			};
			Outputs.Add(OutValue);

			OutValue.Value = Observable.Return((byte?)123);
		}
		
		static OutputTestNode()
		{
			Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<OutputTestNode>));
		}
	}
}
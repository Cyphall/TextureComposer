using System;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace TextureComposer
{
	public class InputTestNode : NodeViewModel
	{
		public ValueNodeInputViewModel<byte?> InValue { get; }

		public InputTestNode()
		{
			Name = "Test Input";

			InValue = new ValueNodeInputViewModel<byte?>
			{
				Name = "Input Value"
			};
			Inputs.Add(InValue);
			
			InValue.ValueChanged.Subscribe(newValue =>
			{
				Console.WriteLine(newValue);
			});
		}
		
		static InputTestNode()
		{
			Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<InputTestNode>));
		}
	}
}
using System.Reactive.Linq;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;
using TextureComposer.DataStructures;
using TextureComposer.Views;

namespace TextureComposer.ViewModels.Nodes
{
	public class SnapNodeViewModel : NodeViewModel
	{
		public ValueNodeInputViewModel<ColorChannel> In { get; } = new();

		public ValueNodeOutputViewModel<ColorChannel> OutWhite { get; } = new();
		public ValueNodeOutputViewModel<ColorChannel> OutBlack { get; } = new();

		public SnapNodeViewModel()
		{
			Name = "Snap";

			In.Name = "Input";
			Inputs.Add(In);


			OutWhite.Name = "Snap to white";
			OutWhite.Value = this
				.WhenAnyValue(vm => vm.In.Value)
				.Select(
					_ => In.Value?.AddModifier(bytes => {
						byte highest = byte.MinValue;
						int length = bytes.Length;
						for (int i = 0; i < length; i++)
						{
							if (bytes[i] > highest) highest = bytes[i];
						}

						for (int i = 0; i < length; i++)
						{
							bytes[i] = (byte) (bytes[i] + (255 - highest));
						}
					})
				);

			Outputs.Add(OutWhite);


			OutBlack.Name = "Snap to black";
			OutBlack.Value = this
				.WhenAnyValue(vm => vm.In.Value)
				.Select(
					_ => In.Value?.AddModifier(bytes => {
						byte lowest = byte.MaxValue;
						int length = bytes.Length;
						for (int i = 0; i < length; i++)
						{
							if (bytes[i] < lowest) lowest = bytes[i];
						}

						for (int i = 0; i < length; i++)
						{
							bytes[i] = (byte) (bytes[i] - lowest);
						}
					})
				);

			Outputs.Add(OutBlack);
		}

		static SnapNodeViewModel()
		{
			Locator.CurrentMutable.Register(() => new StylizedNodeView(), typeof(IViewFor<SnapNodeViewModel>));
		}
	}
}
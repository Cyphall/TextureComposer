using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using ReactiveUI;

namespace TextureComposer
{
	public class MainViewModel : ReactiveObject
	{
		static MainViewModel()
		{
			Splat.Locator.CurrentMutable.Register(() => new MainWindow(), typeof(IViewFor<MainViewModel>));
		}
		
		public NodeListViewModel ListViewModel { get; } = new NodeListViewModel();
		public NetworkViewModel NetworkViewModel { get; } = new NetworkViewModel();

		public MainViewModel()
		{
			ListViewModel.AddNodeType(() => new ComposedTextureNode());
			ListViewModel.AddNodeType(() => new TextureNode());
			// ListViewModel.AddNodeType(() => new InputTestNode());
			// ListViewModel.AddNodeType(() => new OutputTestNode());
		}
	}
}
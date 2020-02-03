using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;

namespace TextureComposer
{
	public class MainViewModel : ReactiveObject
	{
		static MainViewModel()
		{
			Locator.CurrentMutable.Register(() => new MainWindow(), typeof(IViewFor<MainViewModel>));
		}
		
		public NodeListViewModel ListViewModel { get; } = new NodeListViewModel();
		public NetworkViewModel NetworkViewModel { get; } = new NetworkViewModel();

		public MainViewModel()
		{
			ListViewModel.AddNodeType(() => new TextureNodeViewModel());
			ListViewModel.AddNodeType(() => new ComposedTextureNodeViewModel());
			ListViewModel.AddNodeType(() => new InvertNodeViewModel());
			ListViewModel.AddNodeType(() => new ExtractSizeNodeViewModel());
			ListViewModel.AddNodeType(() => new ConstantNodeViewModel());
		}
	}
}
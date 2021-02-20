using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using ReactiveUI;
using Splat;
using TextureComposer.ViewModels.Nodes;
using TextureComposer.Views;

namespace TextureComposer.ViewModels
{
	public class MainViewModel : ReactiveObject
	{
		static MainViewModel()
		{
			Locator.CurrentMutable.Register(() => new MainWindow(), typeof(IViewFor<MainViewModel>));
		}
		
		public NodeListViewModel ListViewModel { get; } = new();
		public NetworkViewModel NetworkViewModel { get; } = new();

		public MainViewModel()
		{
			ListViewModel.AddNodeType(() => new TextureNodeViewModel());
			ListViewModel.AddNodeType(() => new ComposedTextureNodeViewModel());
			ListViewModel.AddNodeType(() => new InvertNodeViewModel());
			ListViewModel.AddNodeType(() => new SnapNodeViewModel());
			ListViewModel.AddNodeType(() => new ConstantNodeViewModel());
		}
	}
}
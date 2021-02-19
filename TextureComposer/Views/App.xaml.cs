using System.Windows;
using NodeNetwork;

namespace TextureComposer.Views
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			NNViewRegistrar.RegisterSplat();
		}
	}
}
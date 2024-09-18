using AppRpgEtec.ViewModels;

namespace AppRpgEtec.Views.Personagens;

public partial class ListagemView : ContentPage
{ 
	ListagemPersonagemViewModel viewModel;

	public ListagemView()
	{
		InitializeComponent();

		viewModel = new ListagemPersonagemViewModel();
		BindingContext = viewModel;
		Title = "Personagens - App RPG ETEC";

	}
}
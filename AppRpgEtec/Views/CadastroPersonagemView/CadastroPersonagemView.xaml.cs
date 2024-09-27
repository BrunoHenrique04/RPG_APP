using AppRpgEtec.ViewModels.Personagens;

namespace AppRpgEtec.Views;

public partial class CadastroPersonagemView : ContentPage
{

	private CadastroPersonagemViewMode cadViewModel;

	public CadastroPersonagemView()
	{
		InitializeComponent();

		cadViewModel = new CadastroPersonagemViewMode();
		BindingContext = cadViewModel;
		Title = "Novo Personagem";
    }
}
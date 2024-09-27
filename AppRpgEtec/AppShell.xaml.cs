using AppRpgEtec.ViewModels.Personagens;
using AppRpgEtec.Views;

namespace AppRpgEtec
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("cadPersonagemView", typeof(CadastroPersonagemView));

            //ViewModel = new AppShellViewModel(); TODO: DESCOMENTAR ISSO DEPOIS
            //BindingContext = ViewModel;
        }
    }
}

using AppRpgEtec.Services.Personagens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;
using AppRpgEtec.Services.Personagens;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;




namespace AppRpgEtec.ViewModels
{
    public class ListagemPersonagemViewModel :  BaseViewModel
    {
        private PersonagensServices pService;
        public ObservableCollection<Personagem> Personagens { get; set; }


        public ListagemPersonagemViewModel() {

            string token = Preferences.Get("UsuarioToken", string.Empty);
            pService = new PersonagensServices(token);
            Personagens = new ObservableCollection<Personagem>();

            _ = ObterPersonagens();
            NovoPersonagem = new Command(async () => { await ExibirCadastroPersonagem(); }); 

        }

        public ICommand NovoPersonagem { get; }

        public async Task ObterPersonagens()
        {
            try
            {
                Personagens = await pService.GetPersonagensAsync();
                OnPropertychanged(nameof(Personagens));
                //await Shell.Current.GoToAsync("cadPersonagemView");

            }
            catch (Exception ex )
            {

                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "Ok");


            }



        }

        public async Task ExibirCadastroPersonagem()
        {
            try
            {
               
                await Shell.Current.GoToAsync("cadPersonagemView");

            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "Ok");


            }



        }



    }
}

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

        }

        public async Task ObterPersonagens()
        {
            try
            {
                Personagens = await pService.GetPersonagensAsync();
                OnPropertychanged(nameof(Personagens));


            }
            catch (Exception ex )
            {

                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "Ok");


            }



        }




    }
}

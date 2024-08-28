using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {


        private UsuarioService _uService;
        public ICommand AutenticarCommand { get; set; }


        public UsuarioViewModel()
        {
            _uService = new UsuarioService();
            InicializarCommands();

        }
        public void InicializarCommands()
        {

            AutenticarCommand = new Command(async () => AutenticarUsuario());
            
        }



        #region AtributosPropiedades  
        private string login = string.Empty;
        
        public string Login 
        {
            get { return login;  }
            set
            {
                login = value;
                OnPropertychanged();

            } 
        }

        public string Password 
        { 
            get { return password; }

            set
            {

                password = value;
                OnPropertychanged();
            }
            
        }
        private string password = string.Empty;



        #endregion

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = login;
                u.PasswordString = password;

                Usuario uAutentico = await _uService.AutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(u.Token))

                {
                    string mensagem = $"Bem bindo {u.Username}";
                    Preferences.Set("UsuarioToken", uAutentico.Token);
                    Preferences.Set("UsuarioId", uAutentico.Id);
                    Preferences.Set("UsuarioUsername", uAutentico.Username);
                    Preferences.Set("UsuarioToken", uAutentico.Perfil);

                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", "Dados incorretos", "Ok");

                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");

            }


        }


    }
}

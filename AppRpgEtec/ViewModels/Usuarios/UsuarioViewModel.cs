using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using AppRpgEtec.Views;
using AppRpgEtec.Views.Personagens;
using AppRpgEtec.Views.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {

        string token = Preferences.Get("UsuarioToken", string.Empty);
        private UsuarioService _uService;
        public ICommand AutenticarCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }


        public UsuarioViewModel()
        {
            _uService = new UsuarioService(token);
            InicializarCommands();

        }
        public void InicializarCommands()
        {

            AutenticarCommand = new Command(async () => AutenticarUsuario());
            RegistrarCommand = new Command(async () => RegistrarUsuario());
           DirecionarCadastroCommand = new Command(async () => DirecionarCadastro());
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

        #region Metodos
        public async Task RegistrarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = Login;
                u.PasswordString = Password;

                Usuario uRegistrado = await _uService.PostRegistrarUsuarioAsync(u);

                if (uRegistrado.Id != 0)
                {
                    String mensagem = $"Usuario Id {uRegistrado.Id} registrado com sucesso";
                    await Application.Current.MainPage.DisplayAlert("Informações", mensagem, "Ok");

                    await Application.Current.MainPage
                            .Navigation.PopAsync();
                }
            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage
                        .DisplayAlert("Informações", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        } 


        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = login;
                u.PasswordString = password;

                Usuario uAutentico = await _uService.AutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutentico.Token))

                {
                    string mensagem = $"Bem vindo {uAutentico.Username}";
                    Preferences.Set("UsuarioToken", uAutentico.Token);
                    Preferences.Set("UsuarioId", uAutentico.Id);
                    Preferences.Set("UsuarioUsername", uAutentico.Username);
                    Preferences.Set("UsuarioPerfil", uAutentico.Perfil);

                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new CadastroPersonagemView(); //ListagemView(); 
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
        
        public async Task DirecionarCadastro()
        {
            try
            {
                await Application.Current.MainPage.
                        Navigation.PushAsync(new CadastrarView());
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Informações", ex.Message + "Detalhes" + ex.InnerException, "Ok");

            }

        }
        
        #endregion

    }
}
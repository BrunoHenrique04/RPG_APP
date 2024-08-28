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



        #region AtributosPropiedades  
        private string login = string.Empty;
        
        public string Login 
        { 
            get => login; 
            set
            {
                Login = value;
                OnPropertychanged();

            } 
        }

        public string Password 
        { 
            get => password;

            set
            {

                password = value;
                OnPropertychanged();
            }
            
        }
        private string password = string.Empty;



        #endregion




    }
}

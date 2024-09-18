using AppRpgEtec.Models;
using AppRpgEtec.Services.Personagens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.ViewModels.Personagens
{
    public class CadastroPersonagemViewMode : BaseViewModel
    {
        private PersonagensServices pService;

        public CadastroPersonagemViewMode()
        {
            string token = Preferences.Get("UsuarioToken",string.Empty);
            pService = new PersonagensServices(token);



        }

        #region  aTRIOBUTO E PROPIEDADES

        private int id;
        private string nome;
        private int pontosVida;
        private int forca;
        private int defesa;
        private int inteligencia;
        private int disputas;
        private int vitorias;
        private int derrotas;
        
        public int Id
        { 
            get => id;
            set 
            { 
                id = value;
                OnPropertychanged();
            }
        
        }

        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertychanged();
            }

        }

        public int PontosVida
        {
            get => pontosVida;
            set
            {
                pontosVida = value;
                OnPropertychanged();
            }

        }

        public int Forca
        {
            get => forca;
            set
            {
                forca = value;
                OnPropertychanged();
            }

        }

        public int Defesa
        {
            get => defesa;
            set
            {
                defesa = value;
                OnPropertychanged();
            }

        }

        public int Inteligencia
        {
            get => inteligencia;
            set
            {
                inteligencia = value;
                OnPropertychanged();
            }

        }

        public int Disputas
        {
            get => disputas;
            set
            {
                disputas = value;
                OnPropertychanged();
            }

        }

        public int Vitorias
        {
            get => vitorias;
            set
            {
                vitorias = value;
                OnPropertychanged();
            }

        }
        public int Derrotas
        {
            get => derrotas;
            set
            {
                derrotas = value;
                OnPropertychanged();
            }

        }

        private ObservableCollection<TipoClasse> listaTiposClasse;
        public ObservableCollection<TipoClasse> ListaTiposClasse
        {
            get { return listaTiposClasse; }

            set
            {
                if (value == null)
                {
                      listaTiposClasse = value;
                      OnPropertychanged();
                }
            }
        }


        public async Task ObterClasse()
        {
            ListaTiposClasse = new ObservableCollection<TipoClasse>();
            ListaTiposClasse.Add(new TipoClasse { Id = 1, Descricao = "Cavaleiro" });
            ListaTiposClasse.Add(new TipoClasse { Id = 2, Descricao = "Mago" });
            ListaTiposClasse.Add(new TipoClasse { Id = 3, Descricao = "Clerigo" });
            OnPropertychanged(nameof(ListaTipoClasse));


        }






    }
}

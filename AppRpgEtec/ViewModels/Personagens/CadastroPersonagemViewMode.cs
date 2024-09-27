using AppRpgEtec.Models;
using AppRpgEtec.Models.Enuns;
using AppRpgEtec.Services.Personagens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace AppRpgEtec.ViewModels.Personagens
{
    public class CadastroPersonagemViewMode : BaseViewModel
    {
        private PersonagensServices pService;

        public ICommand SalvarCommand { get; }

        public CadastroPersonagemViewMode()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            pService = new PersonagensServices(token);
            _ = ObterClasse();

            SalvarCommand = new Command(async () => { await SalvarPersonagem(); });
        }



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
                if (value != null)
                {
                    listaTiposClasse = value;
                    OnPropertychanged();
                }
            }
        }


        public async Task ObterClasse()
        {
            try
            {
                ListaTiposClasse = new ObservableCollection<TipoClasse>();
                ListaTiposClasse.Add(new TipoClasse() { Id = 1, Descricao = "Cavaleiro" });
                ListaTiposClasse.Add(new TipoClasse() { Id = 2, Descricao = "Mago" });
                ListaTiposClasse.Add(new TipoClasse() { Id = 3, Descricao = "Clerigo" });
                OnPropertychanged(nameof(ListaTiposClasse));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }


        }

        private TipoClasse tipoClasseSelecionado;
        public TipoClasse TipoClasseSelecionado
        {
            get { return tipoClasseSelecionado; }
            set
            {
                if (value != null)
                {
                    tipoClasseSelecionado = value;
                    OnPropertychanged();
                }
            }
        }

        public async Task SalvarPersonagem()
        {
            try
            {
                Personagem model = new Personagem()
                {
                    Nome = this.nome,
                    PontosVida = this.pontosVida,
                    Defesa = this.defesa,
                    Derrotas = this.derrotas,
                    Disputas = this.disputas,
                    Forca = this.forca,
                    Inteligencia = this.inteligencia,
                    Vitorias = this.vitorias,
                    Id = this.id,
                    Classe = (ClasseEnum)TipoClasseSelecionado.Id
                };
                if (model.Id == 0)
                    await pService.PostPersonagemAsync(model);

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso", "Ok");

                await Shell.Current.GoToAsync(".."); //remove a pagina atual da pilha de paginas

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }





    }
}

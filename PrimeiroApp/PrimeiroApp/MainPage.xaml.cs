using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrimeiroApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
        }

        int count = 0;
        private void Button_Clicked(object sender, EventArgs e)
        {
            count++;
            ((Button)sender).Text = "você clicou" + count.ToString() + "VEZES";


        }


        private void btnVerificar_Clicked(object sender, EventArgs e)
        {
            string texto = $"o nome tem {txtNome.Text.Length} caracteres";
            DisplayAlert("Mensagem", texto, "Ok!");

        }

        private async void btnLimpar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Pergunta", "Deseja realemente limpar a tela?", "yes", "no")) ;
            {
                txtNome.Text = string.Empty;
                btnCliqueAqui.Text = "Clique aqui";

            }

        }

        private async void btninformaDataNascimento_Clicked(object sender, EventArgs e)
        {
            try//tenta
            {
                string dataDigitada = await DisplayPromptAsync("Info", "Digite a data de nascimento", "Ok");

                DateTime dataConvertida;

                bool converteu = DateTime.TryParse(dataDigitada, 
                    new CultureInfo("pt-br"), DateTimeStyles.None, out dataConvertida);

                if (converteu == false)//lança 
                {
                    throw new Exception("Essa data não é válida");
                }

                else
                {
                    int diasVividos = (int)DateTime.Now.Subtract(dataConvertida).TotalDays;
                    await DisplayAlert("Info", $"você já viveu: {diasVividos}.", "Ok");                }


            }
            catch (Exception ex)//captura
            {
                await DisplayAlert("Erro", ex.Message + ex.InnerException, "Ok");

            }
            
        }

        private async void btnOpcoes_Clicked(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", ex.Message + ex.InnerException, "Ok");
            }
        }
    }
}

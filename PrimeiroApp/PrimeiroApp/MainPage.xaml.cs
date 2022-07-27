using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ((Button)sender).Text = "você clicou" + count.ToString()+ "VEZES";


        }


        private void btnVerificar_Clicked(object sender, EventArgs e)
        {
            string texto = $"o nome tem {txtNome.Text.Length} caracteres";
            DisplayAlert("Mensagem", texto, "Ok!");

        }

        private async void btnLimpar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Pergunta", "Deseja realemente limpar a tela?", "yes", "no")) ;
            btnCliqueAqui.Text = "Clique aqui";
        }
    }
}

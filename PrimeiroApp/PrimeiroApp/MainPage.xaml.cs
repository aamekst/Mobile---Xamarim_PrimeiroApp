﻿using System;
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
            ((Button)sender).Text = "você clicou " + count.ToString() +  " VEZES";


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
                    lblDataNascimento.Text = String.Format("{0:dd/MM/yyyy}", dataConvertida);
                        int diasVividos = (int)DateTime.Now.Subtract(dataConvertida).TotalDays;
                    await DisplayAlert("Info", $"você já viveu: {diasVividos}.", "Ok");               
                }


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
                if (string.IsNullOrEmpty(lblDataNascimento.Text))//verifica se é nulo ou se é digito o que é necessario 
                    throw new Exception("Informe a data de nascimento");

                else
                {
                    DateTime dtNascimento = Convert.ToDateTime(lblDataNascimento.Text, new CultureInfo("pt-br"));

                    string resposta = await
                        DisplayActionSheet("Selecione um opção:", "Cancelar", "",   "Saber o dia da semana", "Saber o dia do ano", "Saber o dia do mês");
                     


                    if (resposta == "Saber o dia da semana")
                    {
                        string diaSemana = String.Empty;

                        switch (dtNascimento.DayOfWeek)
                        {
                            case DayOfWeek.Friday:
                                diaSemana = "Sexta-feira";
                                break;
                            case DayOfWeek.Monday:
                                diaSemana = "Segunda-feira";
                                break;
                            case DayOfWeek.Saturday:
                                diaSemana = "Sábado-feira";
                                break;
                            case DayOfWeek.Sunday:
                                diaSemana = "Domingo-feira";
                                break;
                            case DayOfWeek.Thursday:
                                diaSemana = "Quinta-feira";
                                break;
                            case DayOfWeek.Tuesday:
                                diaSemana = "Terça-feira";
                                break;
                            case DayOfWeek.Wednesday:
                                diaSemana = "Quarta-feira";
                                break;
                            default:
                                break;
                        }
                        string msg = $"Você nasceu no(a) {diaSemana}";
                        await DisplayAlert("Info", msg, "Ok");
                    }

                    else if (resposta == "Saber o dia do mês")
                    {
                        string msg = $"Você nasceu no(a) {dtNascimento.Day} do dia mês";
                        await DisplayAlert("Info", msg, "Ok");
                    }
                    else if (resposta == "Saber o dia do ano")
                    {
                        string msg = $"Você nasceu no(a) {dtNascimento.DayOfYear} do ano";
                        await DisplayAlert("Info", msg, "Ok");
                    }
                   


                }
             }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", ex.Message + ex.InnerException, "Ok");
            }
        }
    }
}

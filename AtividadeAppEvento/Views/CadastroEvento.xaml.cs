using AtividadeAppEvento.Models;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls;

namespace AtividadeAppEvento.Views;

public partial class CadastroEvento : ContentPage
{

    public CadastroEvento()
	{
		InitializeComponent();
        dtpck_inicio.MinimumDate = DateTime.Now;
        dtpck_final.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
        dtpck_final.MinimumDate = dtpck_inicio.Date.AddDays(1);
        dtpck_final.MaximumDate = dtpck_inicio.Date.AddMonths(1);
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try 
        {
            Participantes h = new Participantes
            {
                DataInicio = dtpck_inicio.Date,
                DataFim = dtpck_final.Date,
                Nome = Convert.ToString(str_nome),
                Local = Convert.ToString(str_local),
                Custo = Convert.ToDouble(dou_custo)
            };
            await Navigation.PushAsync(new EventoCadastrado()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
    private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;
        DateTime data_selecionada_inicio = elemento.Date;
        dtpck_final.MinimumDate = data_selecionada_inicio.AddDays(1);
        dtpck_final.MaximumDate = data_selecionada_inicio.AddMonths(1);
    }
}
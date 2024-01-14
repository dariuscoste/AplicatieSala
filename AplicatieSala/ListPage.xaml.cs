using SQLite;
using SQLiteNetExtensions.Attributes;
using AplicatieSala.Models;
using AplicatieSala.Data;

namespace AplicatieSala;
public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ListaAplicatie)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveListaAplicatieAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ListaAplicatie)BindingContext;
        await App.Database.DeleteListaAplicatieAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ListaAplicatie)
        this.BindingContext)
        {
            BindingContext = new Exercitiu()
        });
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ListaAplicatie)BindingContext;

        listView.ItemsSource = await App.Database.GetListaExercitiiAsync(shopl.ID);
    }
}

using AplicatieSala.Models;
using AplicatieSala.Data;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AplicatieSala;

public partial class ListEntryPage : ContentPage
{
	public ListEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetListaExercitiiAsync();
    }
    async void OnListaAplicatieAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new ListaAplicatie()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as ListaAplicatie
            });
        }
    }
}
using SQLite;
using SQLiteNetExtensions.Attributes;
using AplicatieSala.Models;
using AplicatieSala.Data;

namespace AplicatieSala;

public partial class ProductPage : ContentPage
{
    ListaAplicatie sl;
    public ProductPage(ListaAplicatie slist)
    {
        InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var Exercitiu = (Exercitiu)BindingContext;
        await App.Database.SaveExercitiuAsync(Exercitiu);
        listView.ItemsSource = await App.Database.GetExercitiusAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var Exercitiu = (Exercitiu)BindingContext;
        await App.Database.DeleteExercitiuAsync(Exercitiu);
        listView.ItemsSource = await App.Database.GetExercitiusAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetExercitiusAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Exercitiu p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Exercitiu;
            var lp = new ListaExercitii()
            {
                ListaExercitiiID = sl.ID,
                ExercitiuID = p.ID
            };
            await App.Database.SaveListaExercitiiAsync(lp);
            p.ListaExercitii = new List<ListaExercitii> { lp };
            await Navigation.PopAsync();
        }
    }
}
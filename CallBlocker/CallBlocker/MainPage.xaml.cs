using System;
using Xamarin.Forms;

namespace CallBlocker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AtualizaLista();
        }
        async void btnWhitList_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxWhiteListNumber.Text))
            {
                await App.Database.SaveNumberAsync(new WhiteList
                {
                    Number = tbxWhiteListNumber.Text,
                });

                tbxWhiteListNumber.Text = string.Empty;
                AtualizaLista();
            }
        }
        async void AtualizaLista()
        {
            collectionView.ItemsSource = await App.Database.GetNumberAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CallBlocker.Lib.Interfaces;
using System.IO;
using CallBlocker.DA.Database;
using Android.Content;

namespace CallBlocker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private IDatabase getDatabase()
        {
            Context context = Android.App.Application.Context;
            var filePath = context.GetExternalFilesDir("BancoTeste.db").ToString();
            //var filepath = Path.Combine(filePath.ToString(), "BancoTeste.db");
            var db = new Database(filePath);
            return db;
        }
        private void btnWhitList_Clicked(object sender, EventArgs e)
        {
            var teste = new Teste(getDatabase());
            teste.TesteWhite(tbxWhiteListNumber.Text);
        }
    }
}
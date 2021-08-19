using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CallBlocker.Lib.DTO_WhiteList;
using CallBlocker.Lib.Interfaces;
using System.IO;
using CallBlocker.DA.Database;

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
            var filepath = Path.Combine("BancoTeste", "BancoTeste.db");
            var db = new Database(filepath);
            return db;
        }
        private void btnWhitList_Clicked(object sender, EventArgs e)
        {
            var teste = new Teste(getDatabase());
            teste.TesteWhite(tbxWhiteListNumber.Text);
        }
    }
}
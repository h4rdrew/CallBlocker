using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CallBlocker.Lib.DTO_WhiteList;

namespace CallBlocker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnWhitList_Clicked(object sender, EventArgs e)
        {
            var number = new NumberWhiteList();
            number.Number = tbxWhiteListNumber.Text;
        }
    }
}

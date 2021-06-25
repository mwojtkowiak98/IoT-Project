using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodOrderApp.Services;
using FoodOrderApp.ViewModels;

namespace FoodOrderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public int FullPrice1 = 0;
        public MenuPage()
        {
            InitializeComponent();
            ReadMenuViewModel Z = new ReadMenuViewModel();
            Z.GetData();
            Product1.Text = Z.nazwa;
            Product1D.Text = Z.opis;
            Price1.Text = Z.cena;
            Product2.Text = Z.nazwa1;
            Product2D.Text = Z.opis1;
            Price2.Text = Z.cena1;
        }


        private void BtnNext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderAddressPage());
        }

        private void BtnAddP2_Clicked(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(Price2.Text);
            sum(price);
        }

        private void BtnAddP1_Clicked(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(Price1.Text);
            sum(price);
        }

        public void sum(int price)
        {
            FullPrice1 = FullPrice1 + price;
            FullPrice.Text = FullPrice1.ToString() + " $";
        }

    }
}

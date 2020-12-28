//Melanie Bynum
//CIS4930
//Homework 3

using DynamicButtons.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DynamicButtons.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DynamicButtons
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            var handler = new WebRequestHandler();
            var context = DataContext as MainViewModel;

            var weightedProducts = JsonConvert.DeserializeObject<List<InventoryItem>>(handler.Get("http://localhost/ShoppingCartAPI/ShoppingCart/GetWeightProducts").Result);
            weightedProducts.ForEach(context.Products.Add);
            var quantityProducts = JsonConvert.DeserializeObject<List<InventoryItem>>(handler.Get("http://localhost/ShoppingCartAPI/ShoppingCart/GetUnitProducts").Result);
            quantityProducts.ForEach(context.Products2.Add);

            var cart = JsonConvert.DeserializeObject<List<Product>>(handler.Get("http://localhost/ShoppingCartAPI/ShoppingCart/GetCart").Result);
            cart.ForEach(context.Cart.Add);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as MainViewModel).AddToCart();
        }

        private void Cart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as MainViewModel).RemoveFromCart();
        }

        private void checkout_Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (DataContext as MainViewModel).Receipt();
            File.WriteAllText($"{AppDataPaths.GetDefault().LocalAppData}\\receipt.txt", str);
        }

        private void clearcart_Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).ClearCart();
        }

    }
}

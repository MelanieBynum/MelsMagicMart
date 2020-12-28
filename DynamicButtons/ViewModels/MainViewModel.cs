//Melanie Bynum
//CIS4930
//Homework 3

using DynamicButtons.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace DynamicButtons.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<InventoryItem> Products { get; set; }
        public ObservableCollection<InventoryItem> Products2 { get; set; }

        public InventoryItem SelectedProduct { get; set; }
        public ObservableCollection<Product> Cart { get; set; }

        public Product SelectedCartItem { get; set; }

        public string Subtotal => $"Subtotal: {Cart.Sum(i => i.ReturnPrice):C}";
        public string Taxes
        {
            get
            {
                double sub = Convert.ToDouble(Cart.Sum(i => i.ReturnPrice));
                sub *= 0.07;
                string final = "Taxes: "+ sub.ToString("C");
                return final;
            }
        }

        public string Total
        {
            get
            {
                //C currency thing
                double sub = Convert.ToDouble(Cart.Sum(i => i.ReturnPrice));
                sub *= 1.07;
                string final = "Total: " + sub.ToString("C");
                return final;
            }
        }

        public MainViewModel()
        {
            Products = new ObservableCollection<InventoryItem>();
            Cart = new ObservableCollection<Product>();
            Products2 = new ObservableCollection<InventoryItem>();
        }

        public async void AddToCart()
        {
            var product = SelectedProduct;
            var handler = new WebRequestHandler();
            await handler.Post("http://localhost/ShoppingCartAPI/ShoppingCart/AddItem", product);

            if (SelectedProduct == null)
            {
                return;
            }
            if(Cart.Any(i => i.Id.Equals(SelectedProduct.Id)))
            {
                //Cart.FirstOrDefault(i => i.Id.Equals(SelectedProduct.Id)).Units++;
                Cart.FirstOrDefault(i => i.Id.Equals(SelectedProduct.Id)).incUnits();

            } 
            else
            {
                //Cart.Add(new Product { Name = SelectedProduct.Name, Description = SelectedProduct.Description, UnitPrice = SelectedProduct.Price, Units = 1, Id = SelectedProduct.Id });
                if (SelectedProduct.Type == ProductType.ProductByQuantity)
                {
                    Cart.Add(new ProductbyQuantity { Name = SelectedProduct.Name, Description = SelectedProduct.Description, Cost = SelectedProduct.Price, Quantity = 1, Id = SelectedProduct.Id });
                }
                else if (SelectedProduct.Type == ProductType.ProductByWeight)
                {
                    Cart.Add(new ProductbyWeight { Name = SelectedProduct.Name, Description = SelectedProduct.Description, Cost = SelectedProduct.Price, Ounces = 1, Id = SelectedProduct.Id });
                }
            }

            SelectedProduct = null;
            NotifyPropertyChanged("SelectedProduct");
            NotifyPropertyChanged("Taxes");
            NotifyPropertyChanged("Subtotal");
            NotifyPropertyChanged("Total");
        }
        
        public async void RemoveFromCart()
        {
            var handler = new WebRequestHandler();
            await handler.Post("http://localhost/ShoppingCartAPI/ShoppingCart/DeleteItem", SelectedCartItem);

            if (SelectedCartItem == null)
            {
                return;
            }
            if (Cart.Any(i => i.Id.Equals(SelectedCartItem.Id)))
            {
                var cartItem = Cart.FirstOrDefault(i => i.Id.Equals(SelectedCartItem.Id));
                if (cartItem.Units > 1)
                {
                    Cart.FirstOrDefault(i => i.Id.Equals(cartItem.Id)).decUnits();
                } 
                else
                {
                    Cart.Remove(cartItem);
                }
            }

            SelectedCartItem = null;
            NotifyPropertyChanged("SelectedCartItem");
            NotifyPropertyChanged("Total");
            NotifyPropertyChanged("Subtotal");
            NotifyPropertyChanged("Taxes");
        } 

        public async void ClearCart()
        {
            Cart.Clear();
            NotifyPropertyChanged("Total");
            NotifyPropertyChanged("Subtotal");
            NotifyPropertyChanged("Taxes");

            var handler = new WebRequestHandler();
            await handler.Get("http://localhost/ShoppingCartAPI/ShoppingCart/ClearCart");
        }
        public string Receipt()
        {
            string str = "Mel's MagicMart\nItemized Receipt\n----------------\n";

            foreach(var i in Cart)
            {
                str += i.ReturnPrice.ToString("C") + "\t\t" + i.Name + "\n";
            }

            str += "----------------\n" + Subtotal + '\n' + Taxes + '\n' + Total + '\n'; 
            return str;
        }

        //writealltext - instead of save to save file, receipt.txt

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

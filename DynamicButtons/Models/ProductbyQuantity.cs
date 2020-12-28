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

namespace DynamicButtons.Models
{
    public class ProductbyQuantity : Product
    { 
        private double quantity;
        public double Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Display");
            }
        } 

        public override double Units
        {
            get
            {
                return Quantity;
            }
        }

        public override void incUnits() 
        {
            Quantity++;
        }
        public override void decUnits()
        {
            Quantity--;
        }

        public double Cost { get; set; }
        public override double ReturnPrice => Quantity * Cost;

        public override string Display
        {
            get
            {
                return $"{Name} x{Quantity} units";
            }
        }
    }
}

//Melanie Bynum
//CIS4930
//Homework 3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace DynamicButtons.Models
{
    public class ProductbyWeight : Product
    {
        private int ounces;
        public int Ounces
        {
            get
            {
                return ounces;
            }
            set
            {
                ounces = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Display");
            }
        }
        public double Cost { get; set; }
        public override double ReturnPrice => Ounces * Cost;

        public override string Display
        {
            get
            {
                return $"{Name} x{Ounces} oz";
            }
        }

        public override double Units
        {
            get
            {
                return Ounces;
            }
        }

        public override void incUnits()
        {
            Ounces++;
        }
        public override void decUnits()
        {
            Ounces--;
        }
    }
    
}

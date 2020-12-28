//Melanie Bynum
//CIS4930
//Homework 3

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DynamicButtons.Models
{
    [JsonConverter(typeof(ProductJsonConverter))]
    public class Product: INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual string Display { get; }

        public double UnitPrice { get; set; }
        
        public virtual double Units { get; }

        public virtual void incUnits() {}
        public virtual void decUnits() {}
        public virtual double ReturnPrice { get; }

        public Guid Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

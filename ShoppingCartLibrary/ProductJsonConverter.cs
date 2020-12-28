using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DynamicButtons.Models;

namespace DynamicButtons.Models
{
    public class ProductJsonConverter : JsonCreationConverter<Product>
    {
        protected override Product Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");

            if (jObject["Ounces"] != null || jObject["ounces"] != null)
            {
                return new ProductbyWeight();
            }
            else if (jObject["Quantity"] != null || jObject["quantity"] != null)
            {
                return new ProductbyQuantity();
            }
            else
            {
                return new Product();
            }
        }
    }
}

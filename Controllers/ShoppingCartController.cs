using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicButtons.Models;
using Newtonsoft.Json;


namespace ShoppingCartAPI.Controllers
{
    //inventory fetch - get all
    //dataa context for all items -> hardocded list
    //return all valuesi nthe getall
    //postrequest to get product in inventory and put in cart (supportapp)
    //put increment in add or update or in the other thing
    //remove
    //receipt

    [ApiController]
    [Route("ShoppingCart")]
    public class ShoppingCartController : ControllerBase
    {
        [HttpGet("Test")]
        public string Test()
        {
            return "Hi there, world! I'm Melanie Bynum, and this is my homework 4. Enjoy!";
        }

        [HttpGet("GetCart")]
        public ActionResult<List<Product>> GetCart()
        { 
            return Ok(DataContext.cart);
        }
        
        [HttpGet("GetWeightProducts")]
        public ActionResult<List<InventoryItem>> GetWeightProducts()
        {
            return Ok(DataContext.WeightProducts);
        }

        [HttpGet("GetUnitProducts")]
        public ActionResult<List<InventoryItem>> GetUnitProducts()
        {
            return Ok(DataContext.UnitProducts);
        }
        
        [HttpPost("AddItem")]
        public ActionResult<InventoryItem> AddItem([FromBody] InventoryItem product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (DataContext.cart.Any(i => i.Id.Equals(product.Id)))
            {
                var newProduct = DataContext.cart.FirstOrDefault(i => i.Id.Equals(product.Id));
                newProduct.incUnits();
                return product;
            }
            else if (product.Type == ProductType.ProductByQuantity)
            {
                DataContext.cart.Add(new ProductbyQuantity { Name = product.Name, Description = product.Description, Cost = product.Price, Quantity = 1, Id = product.Id });
            }
            else if (product.Type == ProductType.ProductByWeight)
            {
                DataContext.cart.Add(new ProductbyWeight { Name = product.Name, Description = product.Description, Cost = product.Price, Ounces = 1, Id = product.Id });
            }


            return product;
        } 

        [HttpPost("DeleteItem")]
        public ActionResult<Product> DeleteItem([FromBody]Product item)
        {
            Product itemToRemove = DataContext.cart.FirstOrDefault(t => t.Id.Equals(item.Id));

            //units (num)
            if (itemToRemove.Units == 1)
            {
                //itemm = 1, get rid of it
                DataContext.cart.Remove(itemToRemove);

                //if >1, decrement
            }
            else if (itemToRemove.Units > 1)
            {
                itemToRemove.decUnits();
            }

            return itemToRemove;
        }
        
        [HttpGet("ClearCart")]
        public void ClearCart()
        {
            DataContext.cart.Clear();
        }
    }
}

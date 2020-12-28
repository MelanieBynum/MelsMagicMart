using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicButtons.Models;

namespace ShoppingCartAPI
{
    public class DataContext
    {
        public static List<Product> cart = new List<Product>();

        public static List<InventoryItem> WeightProducts = new List<InventoryItem>
        {
            new InventoryItem { Name = "Angel Hair Pasta", Description = "The best type of pasta", Price = 0.89, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Apples", Description = "Red, yellow, and green are available", Price = 0.29, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Chicken", Description = "From your local farm", Price = 0.39, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Grapes", Description = "Brought to you by the Wizard of Wines", Price = 0.19, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Milk", Description = "From Calah's farm", Price = 0.19, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Popcorn", Description = "Movie theater butter popcorn", Price = 0.29, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Rice", Description = "The best jasmine rice", Price = 0.19, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Sour Gummy Worms", Description = "Only the best for our customers", Price = 0.29, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Steak", Description = "Quality meat or your money back", Price = 0.59, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Tangerines", Description = "Fresh from the branch", Price = 0.39, Type = ProductType.ProductByWeight, Id = Guid.NewGuid() },
        };

        public static List<InventoryItem> UnitProducts = new List<InventoryItem>
        {
            new InventoryItem { Name = "Arizona Tea", Description = "Sweet and tasty", Price = 1.29, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Blackberry Lemonade", Description = "Made from the finest blackberries and lemons", Price = 0.99, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Cape Cod Chips", Description = "Original flavor", Price = 2.5, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Cheez-its", Description = "White cheddar flavor", Price = 1.5, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Cherry Coke", Description = "Made from real sugar", Price = 1.99, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Fruit Smiles", Description = "The happiest snack in the world", Price = 2.5, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Goldfish", Description = "The snack that smiles back", Price = 1.99, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Lindor", Description = "Creamy, delicious chocolate", Price = 2.5, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Mint Chocolate Chip", Description = "Your favorite flavor of ice cream", Price =  4.5, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() },
            new InventoryItem { Name = "Nature Valley Bars", Description = "Healthy and tasty", Price = 4.99, Type = ProductType.ProductByQuantity, Id = Guid.NewGuid() }
        };
    }
}

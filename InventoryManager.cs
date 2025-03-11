using System;
using System.Collections.Generic;
using System.Linq;

// namespace this class to organize code
namespace InventoryManagementSystem
{
    class InventoryManager
    {
        // List all products in the inventory
        private List<Product> products = new List<Product>();

        // Adding a product in the inventory
        public void AddProduct(Product product)
        {
            // Prevent duplicate product id from being added by checking if the product id already exist in the inventory
            if (products.Any(p => p.ProductId == product.ProductId))
            {
                Console.WriteLine("Error: Product ID already exists.");
                return;
            }
            // Add the product
            products.Add(product);
            Console.WriteLine("Product added successfully.");
        }

        // Removing a product in the inventory
        public void RemoveProduct()
        {
            ListProducts();
            Console.Write("Enter Product ID to remove: ");

            // Check if the selected product id to remove is integer
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid Product ID.");
                return;
            }

            // Check if the selected product id exist in the inventory
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                Console.WriteLine("Error: Product not found.");
                return;
            }
            Console.WriteLine("=================================");
            Console.WriteLine("Product to be removed:");
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Quantity: {product.QuantityInStock}");
            Console.WriteLine("=================================");

            // Remove the product
            products.Remove(product);
            Console.WriteLine("Product removed successfully.");
        }

        // Updatre a product in the inventory
        public void UpdateProduct()
        {
            ListProducts();
            Console.Write("Enter Product ID to update: ");

            // Check if the selected product id to remove is integer
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid Product ID.");
                return;
            }

            // Check if the selected product id exist in the inventory
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                Console.WriteLine("Error: Product not found.");
                return;
            }

            Console.Write("Enter New Quantity: ");
            // Check if the new quantity is a positive integer otherwise prevent
            if (!int.TryParse(Console.ReadLine(), out int newQuantity) || newQuantity < 0)
            {
                Console.WriteLine("Invalid Quantity.");
                return;
            }
            // Update the quantity of the selected product id
            product.QuantityInStock = newQuantity;
            Console.WriteLine("Product updated successfully.");
        }

        // Displaying all the current products in the inventory
        public void ListProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
                return;
            }
            Console.WriteLine("\n=================================");
            Console.WriteLine("        INVENTORY LIST        ");
            Console.WriteLine("=================================");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId,-5} Name: {product.Name,-15} Quantity: {product.QuantityInStock,-5} Price: {product.Price:C}");
            }
            Console.WriteLine("=================================");
        }

        // Displayt total value of the inventory
        public double GetTotalValue()
        {
            // Calculate the total value of all product in the inventory
            return products.Sum(p => p.QuantityInStock * p.Price);
        }
    }
}

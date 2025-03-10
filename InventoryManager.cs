using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    class InventoryManager
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            if (products.Any(p => p.ProductId == product.ProductId))
            {
                Console.WriteLine("Error: Product ID already exists.");
                return;
            }
            products.Add(product);
            Console.WriteLine("Product added successfully.");
        }

        public void RemoveProduct()
        {
            ListProducts();
            Console.Write("Enter Product ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid Product ID.");
                return;
            }

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

            products.Remove(product);
            Console.WriteLine("Product removed successfully.");
        }

        public void UpdateProduct()
        {
            ListProducts();
            Console.Write("Enter Product ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid Product ID.");
                return;
            }

            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                Console.WriteLine("Error: Product not found.");
                return;
            }

            Console.Write("Enter New Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int newQuantity) || newQuantity < 0)
            {
                Console.WriteLine("Invalid Quantity.");
                return;
            }
            product.QuantityInStock = newQuantity;
            Console.WriteLine("Product updated successfully.");
        }

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

        public double GetTotalValue()
        {
            return products.Sum(p => p.QuantityInStock * p.Price);
        }
    }
}

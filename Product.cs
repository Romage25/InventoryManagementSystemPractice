using System;

// namespace this class to organize code
namespace InventoryManagementSystem
{
    class Product
    {
        // Properties of a product in the inventory system
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }

        public Product(int productId, string name, int quantity, double price)
        {
            // Validation to prevent negative product id
            if (productId <= 0) throw new ArgumentException("Product ID must be a positive integer.");
            // Validation to prevent negative quantity
            if (quantity <= 0) throw new ArgumentException("Quantity cannot be negative or zero.");
            // Validation to prevent negative price
            if (price <= 0) throw new ArgumentException("Price cannot be negative or zero.");

            ProductId = productId;
            Name = name;
            QuantityInStock = quantity;
            Price = price;
        }
    }
}

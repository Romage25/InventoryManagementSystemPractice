using System;

namespace InventoryManagementSystem
{
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }

        public Product(int productId, string name, int quantity, double price)
        {
            if (productId <= 0) throw new ArgumentException("Product ID must be a positive integer.");
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative.");
            if (price < 0) throw new ArgumentException("Price cannot be negative.");

            ProductId = productId;
            Name = name;
            QuantityInStock = quantity;
            Price = price;
        }
    }
}

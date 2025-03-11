// use InventoryManagementSystem namespace 
using InventoryManagementSystem;
using System;

class Program
{
    static void Main()
    {
        InventoryManager inventory = new InventoryManager();

        // run infinitely/continously until user chooses to exit;
        while (true)
        {
            // Clear console for a cleaner user interface
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("   INVENTORY MANAGEMENT SYSTEM   ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Update Product Quantity");
            Console.WriteLine("4. List Products");
            Console.WriteLine("5. Get Total Inventory Value");
            Console.WriteLine("6. Exit");
            Console.WriteLine("=================================");
            Console.Write("Enter your choice: ");

            // Ensures the user's menu selection is a valid integer.
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                Console.ReadKey();
                continue;
            }

            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Product ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                    {
                        Console.WriteLine("Invalid Product ID.");
                        Console.ReadKey();
                        continue;
                    }
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                    {
                        Console.WriteLine("Invalid Quantity.");
                        Console.ReadKey();
                        continue;
                    }
                    Console.Write("Enter Price: ");
                    if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
                    {
                        Console.WriteLine("Invalid Price.");
                        Console.ReadKey();
                        continue;
                    }
                    inventory.AddProduct(new Product(id, name, quantity, price));
                    break;
                case 2:
                    inventory.RemoveProduct();
                    break;
                case 3:
                    inventory.UpdateProduct();
                    break;
                case 4:
                    inventory.ListProducts();
                    break;
                case 5:
                    Console.WriteLine($"Total Inventory Value: {inventory.GetTotalValue():C}");
                    break;
                // Exit the program
                case 6:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}


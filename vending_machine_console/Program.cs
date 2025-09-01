using System;
using System.Linq;
using vending_machine_library.Models;

namespace VendingMachineConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize vending machine
            Vendingmachine vMachine = new Vendingmachine();

            Console.WriteLine("Vending Machine");
            Console.WriteLine("_______________");

            void Trade(Vendingmachine vMachine)
            {
                for (int i = 0; i < vMachine.Slots.Count; i++)
                {
                    var slot = vMachine.Slots[i];
                    if (slot.Products.Count > 0)
                    {
                        Console.WriteLine($"{i}: {slot.Products[0].Name} - {slot.Price} kr. (Stock: {slot.Products.Count})");
                    }
                    else
                    {
                        Console.WriteLine($"{i}: [EMPTY]");
                    }
                }
            }


            bool running = true;

            while (running) //ff
            {
                Console.WriteLine("\nAvailable products:");
                Trade(vMachine); // ff
                //ff
                Console.Write("\nSelect a product slot number (or type 'q' to quit): ");
                string input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    running = false;
                    continue;
                }

                if (!int.TryParse(input, out int slotIndex))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                if (slotIndex < 0 || slotIndex >= vMachine.Slots.Count)
                {
                    Console.WriteLine("Invalid slot index. Try again.");
                    continue;
                }

                // Insert money
                Console.Write("Insert coins (comma separated, fx. 10,5,5): ");
                string coinInput = Console.ReadLine();
                double[] insertedCoins;

                try
                {
                    insertedCoins = coinInput
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(c => double.Parse(c.Trim()))
                        .ToArray();
                }
                catch
                {
                    Console.WriteLine("Invalid coins format. Try again.");
                    continue;
                }

                try
                {
                    var product = vMachine.Buy(slotIndex, insertedCoins);
                    Console.WriteLine($"You bought: {product.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Purchase failed: {ex.Message}");
                }
            }

            Console.WriteLine("Thanks for using the vending machine. Goodbye!");
        }
    }
}

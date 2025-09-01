using System.Security.Cryptography.X509Certificates;
using vending_machine_library.Models;

namespace vending_machine_console
{
    internal class Programming
    {
        static void Main(string[] args)
        {
            Vendingmachine vendingMachine = new Vendingmachine();
            vendingMachine.Buy(2, new double[] { 50});
            Console.WriteLine(vendingMachine.Slots[2].Products.Count);
            ShowSlots(vendingMachine);

            void ShowSlots(Vendingmachine vendingMachine)
            {
                foreach (Slot slot in vendingMachine.Slots)
                {
                    if (slot.Products.Count > 0)
                    {
                        Console.WriteLine($"Der er {slot.Products.Count} x {slot.Products[0].Name}");
                    }
                    else
                    {
                        Console.WriteLine("Denne hylde er tom");
                    }
                    
                    
                }
            }
        }
    }
}

using System;
using System.Text;

class Program
{
    static void Main()
    {
        double applePrice = 1.99, bananaPrice = 2.49, orangePrice = .99, watermelonPrice = 3.99, peachPrice = 1.29;

        // Initialize total price
        double totalPrice = 0.0;

        StringBuilder receipt = new StringBuilder(); // Create a StringBuilder for the receipt

        while (true) // Create a loop for scanning items
        {
            Console.Write("Enter the name of the scanned item (or 'done' to finish): ");
            string itemName = Console.ReadLine().ToLower();

            if (itemName == "done")
            {
                break; // Exit the loop when 'done' is entered
            }

            double itemPrice = 0.0;

            // Use a switch statement to match the scanned item and add its price to the total
            switch (itemName)
            {
                case "apple":
                    itemPrice = applePrice;
                    break;
                case "banana":
                    itemPrice = bananaPrice;
                    break;
                case "orange":
                    itemPrice = orangePrice;
                    break;
                case "watermelon":
                    itemPrice = watermelonPrice;
                    break;
                case "peach":
                    itemPrice = peachPrice;
                    break;
                default:
                    Console.WriteLine("Item not recognized. Please enter a valid item.");
                    continue; // Continue the loop if the item is not recognized
            }

            // Add the item price to the total
            totalPrice += itemPrice;

            // Append the scanned item and its price to the receipt
            receipt.AppendLine($"{itemName}: ${itemPrice:F2}");
        }

        // Print the receipt
        Console.WriteLine($"\nReceipt:\n{receipt}\nTotal Price: ${totalPrice:F2}");
        //Console.WriteLine(receipt);
        //Console.WriteLine($"Total Price: ${totalPrice:F2}");
    }
}

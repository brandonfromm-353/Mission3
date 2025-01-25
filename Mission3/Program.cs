// Brandon Fromm
// Section 3
// Group 9

namespace Mission3;

internal class Program
{
    // creates a list of type FoodItems
    private static List<FoodItems> inventory = new List<FoodItems>();
    
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Food Bank inventory system!");
        
        // loops through the main functions of the program until the user decides to exit
        while (true)
        {
            PrintMainMenu();
            
            // makes sure user's choice is an integer or one of the options between 1 and 4
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                continue;
            }
            
            // different functions are called based on users choice of option
            switch (choice)
            {
                case 1:
                    AddFoodItem();
                    break;
                case 2:
                    DeleteFoodItem();
                    break;
                case 3:
                    PrintFoodItems();
                    break;
                case 4:
                    // returns false if user chooses 4
                    Console.WriteLine("Thank you! Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a number from 1 to 4.");
                    break;
            }
        }
    }
    
    // prints options for ease of reusability
    static void PrintMainMenu()
    {
        Console.WriteLine("\nWould you like to:");
        Console.WriteLine("1. Add a new food item");
        Console.WriteLine("2. Delete a food item");
        Console.WriteLine("3. Show all current food items");
        Console.WriteLine("4. Exit the food bank\n");
    }
    
    // user inputs the needed information for a new item
    static void AddFoodItem()
    {
        Console.WriteLine("Enter the name of the food item: ");
        string name = Console.ReadLine();
        
        Console.WriteLine("Enter the Category of the food item: ");
        string category = Console.ReadLine();
        
        Console.WriteLine("Enter the Quantity of the food item: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Invalid quantity. Must be a positive number");
            return;
        }
        Console.WriteLine("Enter the Expiration Date of the food item (MM/DD/YYYY): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
        {
            Console.WriteLine("Please enter a valid date");
            return;
            
        }
        // adds the new food item to the inventory list
        inventory.Add(new FoodItems(name, category, quantity, expirationDate));
        Console.WriteLine("Food item added");
    }

    static void DeleteFoodItem()
    {
        // makes sure that there are items in the food bank's inventory
        if (inventory.Count == 0)
        {
            Console.WriteLine("There are no items in the food banks inventory to delete.");
            return;
        }
        
        PrintFoodItems();
        
        Console.WriteLine("Enter the number of the food item you would like to delete: ");
        
        // ensures that a valid foot item is selected
        if (!int.TryParse(Console.ReadLine(), out int itemNumber) || itemNumber < 0 || (itemNumber - 1) >= inventory.Count)
        {
            Console.WriteLine("Invalid number. Please try again.");
            return;
        }
        
        // removes the selected food item from the inventory array
        int itemToDelete = itemNumber - 1;
        inventory.RemoveAt(itemToDelete);
        Console.WriteLine($"Food item deleted successfully!");
    }

    static void PrintFoodItems()
    {
        // only prints items if there are items in the inventory
        if (inventory.Count == 0)
        {
            Console.WriteLine("There are no items in inventory.");
            return;
        }
        
        // iterates and prints all the inventory and shifting to start at 1
        Console.WriteLine("\nInventory:");
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }
    }
}
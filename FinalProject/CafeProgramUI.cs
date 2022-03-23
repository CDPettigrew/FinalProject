using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class CafeProgramUI
    {
        private CafeRepository _menuDirectory = new CafeRepository();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine($"Komoddo Cafe Menu Directory\n" +
                    "1. Create a New Menu Item\n" +
                    "2. Show All Current Menu Items\n" +
                    "3. Delete Menu Item\n" +
                    "4. Exit\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        ShowAllMenuItems();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                    case "exit":
                    case "e":
                    default:
                        runMenu = false;
                        break;
                }
            }
        }
        private void CreateNewMenuItem()
        {
            Console.Clear();
            CafeObject menuItem = new CafeObject();
            Console.Write("Please enter Name for the new menu item: ");
            menuItem.Name = Console.ReadLine().ToLower();
            Console.Write("Please enter a description for the menu item: ");
            menuItem.Description = Console.ReadLine().ToLower();
            Console.Write("Please enter an order number for the menu item: ");
            menuItem.MealNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter a list of ingredients for the menu item seperated by a coma with no spaces: ");
            menuItem.Ingredients = Console.ReadLine().ToLower().Split(',').ToList();
            Console.Write("Please enter the price for the menu item: ");
            menuItem.Price = Convert.ToDouble(Console.ReadLine());
            if (_menuDirectory.AddNewMenuItem(menuItem))
            {
                Console.WriteLine($"The menu item {menuItem.Name} was added to the list!");
            }
            else
            {
                Console.WriteLine($"{menuItem.Name} was not added please enter a valid menu item.");
            }
            AnyKey();            
        }
        private void ShowAllMenuItems()
        {
            Console.Clear();
            List<CafeObject> listOfMenuItems = _menuDirectory.ShowAllMenuItems();
            foreach(CafeObject menuItem in listOfMenuItems)
            {
                Console.WriteLine($"Name: {menuItem.Name}\n" +
                    $"Description: {menuItem.Description}\n" +
                    $"Order Number: {menuItem.MealNumber}\n" +
                    $"Price: {menuItem.Price}\n" +
                    $"Ingredients: \n");
                foreach (var x in menuItem.Ingredients)
                {
                    Console.WriteLine(x);
                }
            }
            AnyKey();
        }
        private void DeleteMenuItem()
        {
            List<CafeObject> removeItem = _menuDirectory.ShowAllMenuItems();
            Console.Clear();
            HShowAllMenuItems();
            Console.Write("Please enter the order number of the menu item you wish to delete: ");
            int removedItem = Convert.ToInt32(Console.ReadLine());
            CafeObject menuItem = _menuDirectory.GetMenuItemByOrderNumber(removedItem);
            if (_menuDirectory.DeleteMenuItem(menuItem))
            {
                Console.WriteLine($"{menuItem.Name} has been removed from the menu!");
            }
            else
            {
                Console.WriteLine($"{menuItem.Name} was not removed, something went wrong.");
            }
            AnyKey();
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void HShowAllMenuItems()
        {
            Console.Clear();
            List<CafeObject> listOfMenuItems = _menuDirectory.ShowAllMenuItems();
            foreach (CafeObject menuItem in listOfMenuItems)
            {
                Console.WriteLine($"Name: {menuItem.Name}\n" +
                    $"Description: {menuItem.Description}\n" +
                    $"Order Number: {menuItem.MealNumber}\n" +
                    $"Price: {menuItem.Price}\n" +
                    $"Ingredients: \n");
                foreach(var x in menuItem.Ingredients)
                {
                    Console.WriteLine(x);
                }
            }
        }
    }
}

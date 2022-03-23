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
            SeedContent();
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
                    "4. Exit");
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
            menuItem.Price = Convert.ToDecimal(Console.ReadLine());
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
        /*private void ShowAllMenuItemsTwo()
        {
            Console.Clear();
            Console.WriteLine("      Name      ||            Description                ||   MealNumber   ||   Price   ||");
            List<CafeObject> listOfMenuItems = _menuDirectory.ShowAllMenuItems();
            foreach (CafeObject menuItem in listOfMenuItems)
            {
                string[] indgr = menuItem.Ingredients.ToArray();
                Console.WriteLine($" {menuItem.Name,-18}{menuItem.Description,-50}{menuItem.MealNumber,-10}${menuItem.Price}\n"); //foreach(var x in menuItem.Ingredients) { Console.WriteLine(x); };
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"||   {menuItem.Name}   Ingredients      ||\n");
                Console.WriteLine($"{string.Join(", ", indgr)}");
                Console.WriteLine("-------------------------------------------\n");
            }
            AnyKey();
        }*/
        private void ShowAllMenuItems()
        {
            Console.Clear();
            List<CafeObject> listOfMenuItems = _menuDirectory.ShowAllMenuItems();
            foreach(CafeObject menuItem in listOfMenuItems)
            {
                string[] indgr = menuItem.Ingredients.ToArray();
                Console.WriteLine($"\n Name: {menuItem.Name}\n" +
                    $" Price: {menuItem.Price}\n" +
                    $" {menuItem.Description}\n" +
                    $" Order Number: {menuItem.MealNumber}\n" +
                    $" Ingredients: {string.Join(", ", indgr)}\n");
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
                string[] indgr = menuItem.Ingredients.ToArray();
                Console.WriteLine($"Name: {menuItem.Name}\n" +
                    $"Description: {menuItem.Description}\n" +
                    $"Order Number: {menuItem.MealNumber}\n" +
                    $"Price: {menuItem.Price}\n" +
                    $" Ingredients: {string.Join(", ", indgr)}\n");
            }
        }
        private void SeedContent()
        {
            List<string> ingredients = new List<string>(new string[] { "water", "cheese", "pasta", "salt" });
            var item1 = new CafeObject("macaroni", "pasta an cheese", 1, ingredients, 5.00m);
            List<string> ingredients2 = new List<string>(new string[] { "hamburger", "cheese", "condiments", "tomato", "lettuce", "onion" });
            var item2 = new CafeObject("cheeseburger", "beef patty with assortment of toppings", 2, ingredients2, 6.00m);
            List<string> ingredients3 = new List<string>(new string[] { "pretzel", "cheese" });
            var item3 = new CafeObject("giant pretzel", "a giant pretzel with optional cheese", 3, ingredients3, 3.00m);
            List<string> ingredients4 = new List<string>(new string[] { "beef hot dog", "bun", "condiments", "onions", "pickles", "banana peppers" });
            var item4 = new CafeObject("hot dog", "beef hot dog on a bun with assorted toppings", 4, ingredients4, 5.00m);
            _menuDirectory.AddNewMenuItem(item1);
            _menuDirectory.AddNewMenuItem(item2);
            _menuDirectory.AddNewMenuItem(item3);
            _menuDirectory.AddNewMenuItem(item4);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesProgramUI
    {
        private readonly BadgesRepository _badgeRepository = new BadgesRepository();
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
                Console.WriteLine($"Welcome Security Admin, please select a number option below\n" +
                    $"1. Create a New Badge\n" +
                    $"2. See All Badges And There Access\n" +
                    $"3. Update Door Access on Existing Badge\n" +
                    $"4. Exit The Menu\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        SeeAllBadgesAndThereAllowedDoors();
                        break;
                    case "3":
                        UpdateExistingBadge();
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
        private void CreateNewBadge()
        {
            Console.Clear();
            BadgesObject newBadge = new BadgesObject();
            Console.WriteLine("Please enter an Id number for your new badge: ");
            newBadge.BadgeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter a list of doors you'd like the badge to have access to, split with a coma and no spaces: ");
            newBadge.AllowedAccess = Console.ReadLine().Split(',').ToList();
            if (_badgeRepository.CreateNewBadgeAndAddToDictionary(newBadge))
            {
                Console.WriteLine("Your badge was created and was allowed access to the specified doors!");
            }
            else
            {
                Console.WriteLine("Badge was not create, make sure you enter an ID that hasn't been use yet.");
            }
            AnyKey();
        }
        private void SeeAllBadgesAndThereAllowedDoors()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadges = _badgeRepository.SeeAllBadges();
            foreach (KeyValuePair<int, List<string>> pair in listOfBadges)
            {
                Console.WriteLine($"Badge Id: {pair.Key}");
                Console.WriteLine("Accessable Doors:");
                foreach (var x in pair.Value)
                {
                    Console.WriteLine(x);
                }
            }
            AnyKey();
        }
        private void UpdateExistingBadge()
        {
            HSeeAllBadges();
            Console.Write("Please enter the ID of the badge you'd like to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool runUpdateMenu = true;
            while (runUpdateMenu)
            {
                Console.Clear();
                HSeeAllBadges();
                Console.WriteLine("What would you like to do with the ID?\n" +
                    "1. Add a door\n" +
                    "2. Remove a door\n" +
                    "3. Exit to Main Menu\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("What door would you like to add? ");
                        string door = Console.ReadLine();
                        if (_badgeRepository.AddDoorToBadge(id, door))
                        {
                            Console.WriteLine($"{id} now has access to door {door}");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("What door would you like to remove?");
                        string doorRemove = Console.ReadLine();
                        if (_badgeRepository.RemoveDoorFromBadge(id, doorRemove))
                        {
                            Console.WriteLine($"{id} no longer has access to door {doorRemove}");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong.");
                        }
                        break;
                    case "exit":
                    case "3":
                    default:
                        runUpdateMenu = false;
                        break;

                }
            }
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void HSeeAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadges = _badgeRepository.SeeAllBadges();
            foreach (KeyValuePair<int, List<string>> pair in listOfBadges)
            {
                Console.WriteLine($"Badge Id: {pair.Key}");
                Console.WriteLine("Accessable Doors:");
                foreach (var x in pair.Value)
                {
                    Console.WriteLine(x);
                }
            }
        }
        private void SeedContent()
        {
            List<string> allowedAccess = new List<string>(new string[] {"a1","a2","a3"});
            var badge1 = new BadgesObject(26, allowedAccess);
            List<string> allowedAccess2 = new List<string>(new string[] { "a4", "a5", "a6" });
            var badge2 = new BadgesObject(25, allowedAccess2);
            List<string> allowedAccess3 = new List<string>(new string[] { "a1", "a3", "a5" });
            var badge3 = new BadgesObject(24, allowedAccess3);
            List<string> allowedAccess4 = new List<string>(new string[] { "a2", "a4", "a6" });
            var badge4 = new BadgesObject(23, allowedAccess4);
            _badgeRepository.CreateNewBadgeAndAddToDictionary(badge1);
            _badgeRepository.CreateNewBadgeAndAddToDictionary(badge2);
            _badgeRepository.CreateNewBadgeAndAddToDictionary(badge3);
            _badgeRepository.CreateNewBadgeAndAddToDictionary(badge4);
        }
    }
}

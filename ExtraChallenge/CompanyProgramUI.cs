using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings
{
    public class CompanyProgramUI
    {
        private CompanyRepository _companyDirectory = new CompanyRepository();

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
                Console.WriteLine($"Welcome to the Komodo Outing Planner, Please select a number option below.\n" +
                    $"1. Display all current outings\n" +
                    $"2. Add a new outing\n" +
                    $"3. See the total cost for each outing type\n" +
                    $"4. See the total cost for all outings\n" +
                    $"5. Exit the Outing Planner");
                switch (Console.ReadLine())
                {
                    case "1":
                        SeeAllCurrentOutings();
                        break;
                    case "2":
                        CreateAndAddNewOuting();
                        break;
                    case "3":
                        TotalCostForOutingType();
                        break;
                    case "4":
                        TotalCostForAllOutings();
                        break;
                    case "5":
                    case "exit":
                    case "e":
                    default:
                        runMenu = false;
                        break;
                }
            }
        }
        private void SeeAllCurrentOutings()
        {
            List<CompanyObject> outings = _companyDirectory.DisplayAllOutings();
            Console.Clear();
            foreach (CompanyObject outing in outings)
            {
                Console.WriteLine($"EventType: {outing.TypeOfEvent}\n" +
                    $"Number of Attendees: {outing.NumOfPeople}\n" +
                    $"Date: {outing.EventDate.ToShortDateString()}\n" +
                    $"Cost Per Person: ${outing.CostPerPerson}\n" +
                    $"Total Event Cost: ${outing.CostPerEvent}\n");
            }
            AnyKey();
        }
        private void CreateAndAddNewOuting()
        {
            Console.Clear();
            CompanyObject newOuting = new CompanyObject();
            Console.Write("Please enter an event type from the list provied: Golf,Bowling,Amusement Park,Concert: ");
            switch (Console.ReadLine().ToLower())
            {
                case "golf":
                    newOuting.TypeOfEvent = EventType.Golf;
                    break;
                case "bowling":
                    newOuting.TypeOfEvent = EventType.Bowling;
                    break;
                case "amusement park":
                    newOuting.TypeOfEvent = EventType.AmusementPark;
                    break;
                case "concert":
                    newOuting.TypeOfEvent = EventType.Concert;
                    break;
                default:
                    Console.WriteLine("Please enter a valid event type.");
                    break;
            }
            Console.Write("Please enter the number of attendees: ");
            newOuting.NumOfPeople = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the Date the event will take place, in this format MM/DD/YYYY: ");
            newOuting.EventDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Please enter the cost per person: ");
            newOuting.CostPerPerson = Convert.ToDecimal(Console.ReadLine());
            if (_companyDirectory.CreateNewOuting(newOuting))
            {
                Console.WriteLine($"The {newOuting.TypeOfEvent} event has been added to the list!");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
            AnyKey();
        }
        private void TotalCostForOutingType()
        {
            bool runCostMenu = true;
            while (runCostMenu)
            {
                Console.Clear();
                Console.WriteLine("Please enter an event type listed below to get its total cost \n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n" +
                    "5. Exit back to Main Menu");
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                    case "golf":
                        decimal golfCost = _companyDirectory.ViewTotalGolfCost();
                        Console.WriteLine($"The total cost for golf outings to date is ${golfCost}");
                        AnyKey();
                        break;
                    case "2":
                    case "bowling":
                        decimal bowlingCost = _companyDirectory.ViewTotalBowlingCost();
                        Console.WriteLine($"The total cost for bowling outings to date is ${bowlingCost}");
                        AnyKey();
                        break;
                    case "3":
                    case "amusement park":
                        decimal amusement = _companyDirectory.ViewTotalAmusementParkCost();
                        Console.WriteLine($"The total cost for amusement park outings to date is ${amusement}");
                        AnyKey();
                        break;
                    case "4":
                    case "concert":
                        decimal concert = _companyDirectory.ViewTotalConcertCost();
                        Console.WriteLine($"The total cost for concert outing to date is ${concert}");
                        AnyKey();
                        break;
                    case "5":
                    case "exit":
                    case "e":
                    default:
                        runCostMenu = false;
                        break;
                }
            }
        }
        private void TotalCostForAllOutings()
        {
            Console.Clear();
            decimal totalCost = _companyDirectory.TotalCostOfAllOutings();
            Console.WriteLine($"The total cost for all current company outings is: ${totalCost}");
            AnyKey();
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            DateTime outingDate1 = new DateTime(2022, 06, 25, 00, 00, 00);
            var outing1 = new CompanyObject(20, outingDate1, 100, EventType.Concert);
            DateTime outingDate2 = new DateTime(2022, 08, 05, 00, 00, 00);
            var outing2 = new CompanyObject(15, outingDate2, 200, EventType.AmusementPark);
            DateTime outingDate3 = new DateTime(2022, 05, 15, 00, 00, 00);
            var outing3 = new CompanyObject(30, outingDate3, 50, EventType.Bowling);
            DateTime outingDate4 = new DateTime(2022, 07, 10, 00, 00, 00);
            var outing4 = new CompanyObject(25, outingDate4, 75, EventType.Golf);
            _companyDirectory.CreateNewOuting(outing1);
            _companyDirectory.CreateNewOuting(outing2);
            _companyDirectory.CreateNewOuting(outing3);
            _companyDirectory.CreateNewOuting(outing4);
        }
    }
}

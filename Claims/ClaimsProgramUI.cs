using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimsProgramUI
    {
        private ClaimsRepository _claimDirectory = new ClaimsRepository();
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
                Console.WriteLine($"Welcome to the Komodo Claims Department please choose an option below.\n" +
                    $"1. Enter a New Claim\n" +
                    $"2. Take Care of Next Claim in Queue\n" +
                    $"3. See all Items In the current Queue\n" +
                    $"4. Exit the Menu\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        EnterNewClaim();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        SeeAllClaims();
                        break;
                    case "4":
                    case "exit":
                    case "e":
                        runMenu = false;
                        break;
                }
            }
        }
        private void EnterNewClaim()
        {
            ClaimsObject claim = new ClaimsObject();
            Console.Clear();
            Console.Write("Please enter an id number for your claim: ");
            claim.ClaimId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter a type of claim form the provided list: Car, Home, Theft");
            string claimType = Console.ReadLine().ToLower();
            switch (claimType)
            {
                case "car":
                    claim.TypeOfClaim = ClaimType.Car;
                    break;
                case "home":
                    claim.TypeOfClaim = ClaimType.Home;
                    break;
                case "theft":
                    claim.TypeOfClaim = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please enter a valid claim type.");
                    break;
            }
            Console.Write("Please enter a short description for your claim: ");
            claim.Description = Console.ReadLine();
            Console.Write("Please enter the dollar amount of your claim: ");
            claim.ClaimAmount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the date of the incident in this format MM/DD/YY: ");
            claim.IncidentDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Please enter the date you submitted the claim in this format MM/DD/YY: ");
            claim.ClaimDate = Convert.ToDateTime(Console.ReadLine());
            int result = (claim.ClaimDate - claim.IncidentDate).Days;
            if (result <= 30)
            {
                claim.IsValid = true;
            }
            else
            {
                claim.IsValid = false;
            }
            if (_claimDirectory.EnterNewClaim(claim))
            {
                Console.WriteLine("Your claim was added to the queue!");
            }
            else
            {
                Console.WriteLine("Claim was not added please try again.");
            }
            AnyKey();
        }
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<ClaimsObject> listOfClaims = _claimDirectory.GetAllClaims();
            foreach (var claim in listOfClaims)
            {
                Console.WriteLine($"Claim Id: {claim.ClaimId}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Claim Description: {claim.Description}\n" +
                    $"Claim Amount: ${claim.ClaimAmount}\n" +
                    $"Date of Claim Incident: {claim.IncidentDate}\n" +
                    $"Date Claim Was Made: {claim.ClaimDate}\n" +
                    $"Is the Claim Valid: {claim.IsValid}\n");
            }
            AnyKey();
        }
        private void TakeCareOfNextClaim()
        {
            ClaimsObject nextClaim = _claimDirectory.GetFirstInQueue();
            Console.Clear();
            Console.WriteLine($"Claim Id: {nextClaim.ClaimId}\n" +
                $"Claim Type: {nextClaim.TypeOfClaim}\n" +
                $"Claim Description: {nextClaim.Description}\n" +
                $"Claim Amount: ${nextClaim.ClaimAmount}\n" +
                $"Date of Claim Incident: {nextClaim.IncidentDate}\n" +
                $"Date Claim Was Made: {nextClaim.ClaimDate}\n" +
                $"Is the Claim Valid: {nextClaim.IsValid}\n");

            Console.Write("Would you like to handle this claim? ");
            switch (Console.ReadLine().ToLower())
            {
                case "yes":
                case "y":
                    _claimDirectory.TakeCareOfNextClaim();
                    Console.WriteLine("Press enter when finished handling current claim.");
                    Console.ReadKey();
                    break;
                case "no":
                case "n":
                default:
                    //AnyKey();
                    break;
            }
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            //when entering a claim in the UI you can input the two dates, but the seed content wasn't happy with the dates so I had to take them out
            var claimOne = new ClaimsObject(1, ClaimType.Car, "car crash", 500, true);
            var claimTwo = new ClaimsObject(2, ClaimType.Home, "tree destroyed house", 5000, true);
            var claimThree = new ClaimsObject(3, ClaimType.Theft, "valuables taken", 50000, true);
            var claimFour = new ClaimsObject(4, ClaimType.Theft, "car stolen from house", 1000, true);
            _claimDirectory.EnterNewClaim(claimOne);
            _claimDirectory.EnterNewClaim(claimTwo);
            _claimDirectory.EnterNewClaim(claimThree);
            _claimDirectory.EnterNewClaim(claimFour);
        }
    }
}

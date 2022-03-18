using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesRepository
    {
        protected Dictionary<int , List<string>> _badgesDictionary = new Dictionary<int, List<string>>();
        
        //C
        public void CreateDictionaryOfBadges()
        {

        }
        public bool CreateNewBadge(int id, List<string> accessibleDoors)
        {
            int intialCount = _badgesDictionary.Count();
            _badgesDictionary.Add(id, accessibleDoors);

            if(_badgesDictionary.Count() > intialCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //R
        public Dictionary<int, List<string>> SeeAllBadges()
        {
            return _badgesDictionary;
        }
        public Dictionary<int, List<string>> GetBadgeById(int id)
        {
            return (Dictionary<int, List<string>>)_badgesDictionary.Where(b => b.Key == id).DefaultIfEmpty();
        }
        //U
        public void UpdateAllowedDoorsForBadges()
        {

        }
        //D
        /*public bool DeleteDoorsFromBadge(int id)
        {
            int intialCount = _badgesDictionary.Count();
            _badgesDictionary.Remove(List<>);
        }*/
    }
}

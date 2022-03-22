using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesRepository
    {
        protected List<BadgesObject> _badgesRepository = new List<BadgesObject>();
        protected Dictionary<int, List<string>> _badgesDictionary = new Dictionary<int, List<string>>();
        //C
        public bool CreateNewBadgeAndAddToDictionary(BadgesObject badge)
        {
            int intialCount = _badgesRepository.Count();
            int initialDCount = _badgesDictionary.Count();
            if (!_badgesDictionary.ContainsKey(badge.BadgeID) && !_badgesRepository.Contains(badge))
            {
                _badgesRepository.Add(badge);
                _badgesDictionary.Add(badge.BadgeID, badge.AllowedAccess);
                if (_badgesRepository.Count() > intialCount && _badgesDictionary.Count > initialDCount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
        //U
        public bool AddDoorToBadge(int id, string door)
        {
            if (_badgesDictionary.ContainsKey(id))
            {
                _badgesDictionary[id].Add(door);
                return true;
            }
            else
            {
                return false;
            }
        }
        //D
        public bool RemoveDoorFromBadge(int id, string door)
        {
            if (_badgesDictionary.ContainsKey(id))
            {
                _badgesDictionary[id].Remove(door);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

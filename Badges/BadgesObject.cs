using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesObject
    {
        public int BadgeID { get; set; }
        public List<string> AllowedAccess { get; set; }

        Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>(); 

        public BadgesObject() { }
        public BadgesObject(int badgeId, List<string> allowedAccess)
        {
            BadgeID = badgeId;
            AllowedAccess = allowedAccess;
        }
        
    }
}

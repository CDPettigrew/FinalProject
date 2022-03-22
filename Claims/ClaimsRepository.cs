using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimsRepository
    {
        protected Queue<ClaimsObject> _claimDirectory = new Queue<ClaimsObject>();
        //C
        public bool EnterNewClaim(ClaimsObject claim)
        {
            int initialCount = _claimDirectory.Count();
            if (!_claimDirectory.Contains(claim))
            {
                _claimDirectory.Enqueue(claim);
                if (_claimDirectory.Count() > initialCount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        //R
        public ClaimsObject TakeCareOfNextClaim()
        {
            return _claimDirectory.Dequeue();
        }
        public ClaimsObject GetFirstInQueue()
        {
            return _claimDirectory.Peek();
        }
        //D
        public Queue<ClaimsObject> GetAllClaims()
        {
            return _claimDirectory;
        }
    }
}

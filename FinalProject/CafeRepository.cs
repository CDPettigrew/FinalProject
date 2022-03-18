using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class CafeRepository
    {
        protected List<CafeObject> _menuDirectory = new List<CafeObject>();
        //C
        public bool CreateNewMenuItem(CafeObject menuItem)
        {
            int initialItemCount = _menuDirectory.Count();
            _menuDirectory.Add(menuItem);

            if (_menuDirectory.Count > initialItemCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //R
        public List<CafeObject> ShowAllMenuItems()
        {
            return _menuDirectory;
        }
        public CafeObject GetMenuItemByOrderNumber(int mealNumber)
        {
            foreach(CafeObject menuItem in _menuDirectory)
            {
                if(menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
        //D
        public bool DeleteMenuItem(CafeObject menuItem)
        {
            int initialItemCount = _menuDirectory.Count();
            _menuDirectory.Remove(menuItem);

            if (_menuDirectory.Count > initialItemCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

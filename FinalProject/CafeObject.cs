using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class CafeObject
    {
        public string Name { get; set; }
        public int MealNumber { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public int Price { get; set; }

        public CafeObject() { }
        public CafeObject(string name, int mealNumber, string description, List<string> ingredients, int price)
        {
            Name = name;
            MealNumber = mealNumber;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }


    }
}

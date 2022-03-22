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
        public double Price { get; set; }
        public CafeObject() { }
        public CafeObject(string name, string description, int mealNumber, double price)
        {
            Name = name;
            Description = description;
            MealNumber = mealNumber;
            Price = price;
        }
        public CafeObject(string name,string description ,int mealNumber , List<string> ingredients, double price)
        {
            Name = name;
            MealNumber = mealNumber;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}

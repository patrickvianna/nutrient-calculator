using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using nutrienteCalculator.App.Entities.Models;

namespace nutrientCalculator.App.Entities.Models
{
    public class Meal : Entity
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }

        private List<MealFood> _mealFood;
        public List<MealFood> Foods
        {
            get { return _mealFood; }
            set { _mealFood = value; }
        }

        private List<FoodNutrient> _foodNutrients;
        [NotMapped]
        public List<FoodNutrient> Nutrients
        {
            get { return _foodNutrients; }
            private set { _foodNutrients = value; }
        }
        public Meal()
        {
            Nutrients = new List<FoodNutrient>();
            Foods = new List<MealFood>();
        }

        public Meal(string name, DateTime time)
            : this()
        {
            Name = name;
            Time = time;
            _mealFood = new List<MealFood>();
        }

        public void AddFood(Food food, double quantity)
        {
            _mealFood.Add(new MealFood(food, quantity));
        }

        public List<FoodNutrient> GetNutrientTable()
        {
            _mealFood.ForEach(food => {
                var nutrientTable = food.CalculateNutrientTable();
                SumNutrientsTable(nutrientTable);
            });

            return Nutrients;
        }

        private void SumNutrientsTable(List<FoodNutrient> nutrientsComing)
        {
            List<FoodNutrient> nutrientsToInsertInTable = new List<FoodNutrient>();

            var i = 0;
            do
            {
                foreach (var nutrient in nutrientsComing)
                {
                    FoodNutrient nutrientToInsert = nutrient;
                    if (Nutrients.Count() != 0 && Nutrients[i]?.Nutrient == nutrient.Nutrient)
                    {
                        Nutrients[i].Quantity += nutrient.Quantity;
                        nutrientToInsert = null;
                    }

                    if (nutrientToInsert != null)
                        nutrientsToInsertInTable.Add(nutrientToInsert);
                }
            } while (i < Nutrients.Count());

            Nutrients = nutrientsToInsertInTable;
        }
    }
}

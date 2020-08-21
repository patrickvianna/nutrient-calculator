using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nutrienteCalculator.App.Entities.Models
{
    public class Food : Entity
    {
        [Required(ErrorMessage = "Nome do alimento é obrigatório")]
        [StringLength(60, ErrorMessage = "Nome tem que ter no máximo {0} caracteres")]
        public string Name { get; set; }
        public string Description { get; set; }

        private List<FoodNutrient> _foodNutrients;

        public List<FoodNutrient> Nutrients
        {
            get { return _foodNutrients; }
            set { _foodNutrients = value; }
        }

        public Food()
        {
            Nutrients = new List<FoodNutrient>();
        }

        public Food(string name, string description)
            :this()
        {
            Name = name;
            Description = description;
        }
    }

    public class MealFood : Entity
    {
        public Food Food { get; set; }
        public double Quantity { get; set; }

        public MealFood() { }
        public MealFood(Food food, double quantity)
        {
            Food = food;
            Quantity = quantity;
        }

        public List<FoodNutrient> CalculateNutrientTable()
        {
            List<FoodNutrient> nutrients = new List<FoodNutrient>();

            Food.Nutrients.ForEach(nutrient => {
                nutrient.Quantity = nutrient.Quantity * (Quantity / 100);
                nutrients.Add(nutrient);
            });

            return nutrients;
        }
    }
}

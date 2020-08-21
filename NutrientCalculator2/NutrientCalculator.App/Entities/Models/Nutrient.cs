using NutrientCalculator.App.Entities;
using NutrientCalculator.App.Entities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nutrienteCalculator.App.Entities.Models
{
    //public class Nutrient : Entity
    //{
    //    [Required(ErrorMessage = "Nome do nutriente é obrigatorio é obrigatório")]
    //    public string Name { get; set; }

    //    public Nutrient(string name)
    //    {
    //        Name = name;
    //    }
    //    public Nutrient()
    //    {

    //    }
    //}

    public class FoodNutrient : Entity
    {
        public eNutrient Nutrient { get; set; }
        [Required(ErrorMessage = "Quantidade é obrigatório")]
        public double Quantity { get; set; }

        public FoodNutrient(int nutrient, double quantity)
        {
            Nutrient = (eNutrient)nutrient;
            Quantity = quantity;
        }

        public FoodNutrient()
        {

        }
    }

    //[NotMapped]
    //public class Nutrients
    //{
    //    [NotMapped]
    //    public List<FoodNutrient> List { get; set; }

    //    public Nutrients()
    //    {
    //        List = new List<FoodNutrient>();
    //    }

    //    public void AddNutrient(int nutrient, double quantity)
    //    {
    //        List.Add(new FoodNutrient(nutrient, quantity));
    //    }
    //}
}

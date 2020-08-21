using nutrienteCalculator.App.Data.Context;
using nutrienteCalculator.App.Entities.Models;
using nutrienteCalculator.App.Interfaces.Repository;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nutrienteCalculator.App.Data.Repository
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        private IRepository<FoodNutrient> _foodNutrientRepository;

        public FoodRepository(DataContext context, IRepository<FoodNutrient> foodNutrientRepository)
            : base(context)
        {
            _foodNutrientRepository = foodNutrientRepository;
        }

        public async Task<List<Food>> GetAllFood()
        {
            var foods = Context.Foods.Where(x => x.Id != null)
                .Include(x => x.Nutrients)
                .AsNoTracking();
            return await foods.ToListAsync();
        }

        public async Task<bool> SaveFood(Food food)
        {
            var savedFood = SelectByCondition(x => x.Name.ToUpper() == food.Name.ToUpper()).FirstOrDefault();
            if (food.Id != savedFood.Id)
                return false;

            if (food.Id != null) await UpdateAsync(food);
            else await InsertAsync(food);

            await SaveNutrients(food.Nutrients);

            return true;
        }

        private async Task SaveNutrients(List<FoodNutrient> nutrients)
        {
            foreach (FoodNutrient nutrient in nutrients)
            {
                var savedNutrient = _foodNutrientRepository.SelectByCondition(x => x.Nutrient == nutrient.Nutrient).FirstOrDefault();
                if (savedNutrient != null)
                {
                    savedNutrient.Quantity = nutrient.Quantity;
                    await _foodNutrientRepository.UpdateAsync(savedNutrient);
                }
                else
                    await _foodNutrientRepository.InsertAsync(nutrient);
            }
        }
    }
}

using nutrienteCalculator.App.Data.Context;
using nutrienteCalculator.App.Entities.Models;
using nutrienteCalculator.App.Interfaces.Repository;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using nutrientCalculator.App.Entities.Models;
using System;

namespace nutrienteCalculator.App.Data.Repository
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        private IRepository<MealFood> _mealFoodRepository;
        private IFoodRepository _foodRepository;

        public MealRepository(DataContext context, IRepository<MealFood> MealFoodRepository, IFoodRepository foodRepository)
            : base(context)
        {
            _mealFoodRepository = MealFoodRepository;
            _foodRepository = foodRepository;
        }

        public async Task<List<Meal>> GetAllMeal()
        {
            var meals = Context.Meals
                .Include(x => x.Foods)
                .ThenInclude(x => x.Food)
                .AsNoTracking();
            return await meals.ToListAsync();
        }
        
        public async Task<Meal> GetMeal(Guid id)
        {
            var meals = Context.Meals
                .Include(x => x.Foods)
                .ThenInclude(x => x.Food)
                .ThenInclude(x => x.Nutrients)
                .Where(x => x.Id.Equals(id))
                .AsNoTracking();
            return await meals.FirstOrDefaultAsync();
        }

        public async Task SaveMeal(Meal meal)
        {
            meal.Time = DateTime.Now;
            meal.Foods = await AssociateFood(meal.Foods);
            await SaveAsync(meal);
            //await SaveFoods(meal);
        }

        private async Task<List<MealFood>> AssociateFood(List<MealFood> mealFoods)
        {
            foreach (MealFood item in mealFoods)
            {
                item.Food = (item.Food.Id == Guid.Empty) ? null : await _foodRepository.SelectAsync(item.Food.Id);                
            }

            return mealFoods;
        }

        //private async Task SaveFoods(Meal meal)
        //{
        //    var savedFoods =_mealFoodRepository.SelectByCondition(x => x.Food.Id == meal.Id).ToList();
        //    Context.MealFoods.RemoveRange(savedFoods);
            
        //    foreach (MealFood food in meal.Foods)
        //    {
        //        await _mealFoodRepository.InsertAsync(food);
        //    }

        //    await Context.SaveChangesAsync();
        //}

    }
}

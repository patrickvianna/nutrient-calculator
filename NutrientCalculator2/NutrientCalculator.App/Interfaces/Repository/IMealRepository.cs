using nutrientCalculator.App.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nutrienteCalculator.App.Interfaces.Repository
{
    public interface IMealRepository : IRepository<Meal>
    {
        Task SaveMeal(Meal meal);
        Task<List<Meal>> GetAllMeal();
        Task<Meal> GetMeal(Guid id);
    }
}

using nutrienteCalculator.App.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nutrienteCalculator.App.Interfaces.Repository
{
    public interface IFoodRepository : IRepository<Food>
    {
        Task<bool> SaveFood(Food food);
        Task<List<Food>> GetAllFood();
    }
}

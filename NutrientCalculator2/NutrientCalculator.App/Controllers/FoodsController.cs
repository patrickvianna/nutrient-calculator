using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nutrienteCalculator.App.Entities.Models;
using nutrienteCalculator.App.Interfaces.Repository;

namespace NutrientCalculator.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private IFoodRepository _repository;

        public FoodsController(IFoodRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _repository.GetAllFood());
        }

        [HttpPost("Save")]
        public async Task Save([FromBody] Food food)
        {
            await _repository.SaveFood(food);
        }
    }
}

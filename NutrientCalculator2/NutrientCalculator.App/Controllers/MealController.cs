using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nutrientCalculator.App.Entities.Models;
using nutrienteCalculator.App.Interfaces.Repository;

namespace NutrientCalculator.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private IMealRepository _repository;

        public MealController(IMealRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _repository.GetAllMeal());
        }

        [HttpPost("Save")]
        public async Task Save([FromBody] Meal meal)
        {
            await _repository.SaveMeal(meal);
        }

        [HttpGet("GetTableNutrients/{id}")]
        public async Task<ActionResult> GetTableNutrients(Guid id)
        {
            var meal = await _repository.GetMeal(id);
            
            return Ok(meal.GetNutrientTable());

        }
    }
}

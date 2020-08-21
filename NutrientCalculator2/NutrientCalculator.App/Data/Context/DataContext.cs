using Microsoft.EntityFrameworkCore;
using nutrientCalculator.App.Entities.Models;
using nutrienteCalculator.App.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nutrienteCalculator.App.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<FoodNutrient> FoodNutrients { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<MealFood> MealFoods { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}

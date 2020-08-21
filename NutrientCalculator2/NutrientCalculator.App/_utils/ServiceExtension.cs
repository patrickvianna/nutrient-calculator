using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nutrienteCalculator.App.Data.Context;
using nutrienteCalculator.App.Data.Repository;
using nutrienteCalculator.App.Interfaces.Repository;

namespace NutrientCalculator.App._utils
{
    public static class ServiceExtension
    {
        public static void ConfigureRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<DataContext>(o => o.UseMySql(connectionString));
        }
    }
}

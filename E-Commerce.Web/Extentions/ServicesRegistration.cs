using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Extentions
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddSwaggerServcies(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
           Services.AddSwaggerGen();
            return Services;
        }

        public static IServiceCollection AddWepApplicationServices(this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorResponse;

            });

            return Services;
        }
    }
}

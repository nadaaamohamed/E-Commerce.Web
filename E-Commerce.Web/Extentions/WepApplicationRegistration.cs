using DomainLayer.Contarcts;
using E_Commerce.Web.CustomMiddleWare;
using Microsoft.AspNetCore.Builder;

namespace E_Commerce.Web.Extentions
{
    public static class WepApplicationRegistration
    {
        public static async Task SeedDataBaseAsync(this WebApplication app)
        {
            using var Scope = app.Services.CreateScope();
            var ObjectOfDataSeedind = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await ObjectOfDataSeedind.SeedDataAsync();

        }

        public static IApplicationBuilder UseCustomExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleWare>();

            return app;
        }

        public static IApplicationBuilder UseSwaggerMiddleWares(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}

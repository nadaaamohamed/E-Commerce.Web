
using Azure;
using DomainLayer.Contarcts;
using E_Commerce.Web.CustomMiddleWare;
using Microsoft.EntityFrameworkCore;
using Presistence;
using Presistence.Data;
using Presistence.Repositories;
using Service;
using ServiceAbstraction;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Add services to the container builder.Services.AddControllers();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<IUintOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(Service.AssmeplyReference).Assembly);
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            #endregion


            var app = builder.Build();

            using var Scope = app.Services.CreateScope();
            var ObjectOfDataSeedind = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await ObjectOfDataSeedind.SeedDataAsync();



            #region Configure the HTTP request pipeline.
            //app.Use(async (RequestContext, NextMiddleWare) =>
            //{
            //    Console.WriteLine("Request Under Processing");
            //   await  NextMiddleWare.Invoke();
            //    Console.WriteLine("Waiting Responses");
            //    Console.WriteLine(RequestContext.Response.Body);
            //});
            app.UseMiddleware<CustomExceptionHandlerMiddleWare>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.MapControllers();
                #endregion

            }
            app.Run();

        }

    }
}
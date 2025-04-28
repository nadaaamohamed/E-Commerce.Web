
using Azure;
using DomainLayer.Contarcts;
using E_Commerce.Web.CustomMiddleWare;
using E_Commerce.Web.Extentions;
using E_Commerce.Web.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistence;
using Presistence.Data;
using Presistence.Repositories;
using Service;
using ServiceAbstraction;
using Shared.ErrorModels;

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
            builder.Services.AddSwaggerServcies();    
            builder.Services.AddInferaStructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddWepApplicationServices();


            #endregion


            var app = builder.Build();

             await app.SeedDataBaseAsync();



            #region Configure the HTTP request pipeline.
            //app.Use(async (RequestContext, NextMiddleWare) =>
            //{
            //    Console.WriteLine("Request Under Processing");
            //   await  NextMiddleWare.Invoke();
            //    Console.WriteLine("Waiting Responses");
            //    Console.WriteLine(RequestContext.Response.Body);
            //});

            app.UseCustomExceptionMiddleWare();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddleWares();
            }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.MapControllers();
            
                #endregion

            
            app.Run();

        }

    }
}
using DomainLayer.Contarcts;
using DomainLayer.Models.ProductsModule;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence
{
    public class DataSeeding (StoreDbContext _dbContext): IDataSeeding
    {
        public async Task SeedDataAsync()
        {
          
            var PendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();    

            try
            {
                if (PendingMigrations.Any())
                {
                    await _dbContext.Database.MigrateAsync();
                }
                if (!_dbContext.Set<ProductBrand>().Any())
                {
                    //var ProdtuctBrandData =await File.ReadAllTextAsync(@"..\infrastructure\Presistence\Data\DataSeed\brands.json");
                    var ProdtuctBrandData = File.OpenRead(@"..\infrastructure\Presistence\Data\DataSeed\brands.json");
                    //Convert Data "string" to C# object
                    var ProductBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProdtuctBrandData);
                    if (ProductBrands is not null && ProductBrands.Any())
                       await _dbContext.ProductBrands.AddRangeAsync(ProductBrands);
                    //_dbContext.SaveChanges();

                }

                if (!_dbContext.Set<ProductType>().Any())
                {
                    var ProdtuctTypeData = File.OpenRead(@"..\infrastructure\Presistence\Data\DataSeed\types.json");
                    //Convert Data "string" to C# object
                    var ProductTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProdtuctTypeData);
                    if (ProductTypes is not null && ProductTypes.Any())
                      await  _dbContext.ProductTypes.AddRangeAsync(ProductTypes);
                    //_dbContext.SaveChanges();

                }
                if (!_dbContext.Set<Product>().Any())
                {
                    var ProdtuctData = File.OpenRead(@"..\infrastructure\Presistence\Data\DataSeed\products.json");
                    //Convert Data "string" to C# object
                    var Products =await JsonSerializer.DeserializeAsync<List<Product>>(ProdtuctData);
                    if (Products is not null && Products.Any())
                       await _dbContext.Products.AddRangeAsync(Products);
                    //_dbContext.SaveChanges();

                }
               await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Log the error
                //throw new Exception("Problem seeding data", ex);
            }

        }
    }
}
 
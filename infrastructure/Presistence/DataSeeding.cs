using DomainLayer.Contarcts;
using DomainLayer.Models;
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
        public void SeedData()
        {
          

            try
            {
                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    _dbContext.Database.Migrate();
                }
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProdtuctBrandData = File.ReadAllText(@"..\infrastructure\Presistence\Data\DataSeed\brands.json");
                    //Convert Data "string" to C# object
                    var ProductBrands = JsonSerializer.Deserialize<List<ProductBrand>>(ProdtuctBrandData);
                    if (ProductBrands is not null && ProductBrands.Any())
                        _dbContext.ProductBrands.AddRange(ProductBrands);
                    //_dbContext.SaveChanges();

                }

                if (!_dbContext.ProductTypes.Any())
                {
                    var ProdtuctTypeData = File.ReadAllText(@"..\infrastructure\Presistence\Data\DataSeed\types.json");
                    //Convert Data "string" to C# object
                    var ProductTypes = JsonSerializer.Deserialize<List<ProductType>>(ProdtuctTypeData);
                    if (ProductTypes is not null && ProductTypes.Any())
                        _dbContext.ProductTypes.AddRange(ProductTypes);
                    //_dbContext.SaveChanges();

                }
                if (!_dbContext.Products.Any())
                {
                    var ProdtuctData = File.ReadAllText(@"..\infrastructure\Presistence\Data\DataSeed\products.json");
                    //Convert Data "string" to C# object
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProdtuctData);
                    if (Products is not null && Products.Any())
                        _dbContext.Products.AddRange(Products);
                    //_dbContext.SaveChanges();

                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Log the error
                //throw new Exception("Problem seeding data", ex);
            }

        }
    }
}
 
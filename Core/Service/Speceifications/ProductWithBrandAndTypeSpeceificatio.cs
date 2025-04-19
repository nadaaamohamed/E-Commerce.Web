using DomainLayer.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Speceifications
{
     class ProductWithBrandAndTypeSpeceificatio :BaseSpeceification<Product , int>
    {
        public ProductWithBrandAndTypeSpeceificatio(ProductQueryParams queryParams) :base(p=>(!queryParams.BrandId.HasValue || p.BrandId==queryParams.BrandId) &&(!queryParams.TypeId.HasValue || p.TypeId== queryParams.TypeId)  )
        {

            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            switch(queryParams.SortingOptions)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;

                default:
                    break;


            }
        }

    }
}

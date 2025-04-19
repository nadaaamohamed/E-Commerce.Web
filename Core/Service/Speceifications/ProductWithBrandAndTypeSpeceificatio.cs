using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Speceifications
{
     class ProductWithBrandAndTypeSpeceificatio :BaseSpeceification<Product , int>
    {
        public ProductWithBrandAndTypeSpeceificatio(int ? BrandId , int ? TypeId) :base(p=>(!BrandId.HasValue || p.BrandId==BrandId) &&(!TypeId.HasValue || p.TypeId==TypeId))
        {

            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);

        }

    }
}

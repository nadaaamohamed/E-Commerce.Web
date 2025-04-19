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
        public ProductWithBrandAndTypeSpeceificatio() :base(null)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);

        }

    }
}

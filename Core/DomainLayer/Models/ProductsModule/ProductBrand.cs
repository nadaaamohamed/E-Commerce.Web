﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.ProductsModule
{
    public class ProductBrand : BaseEntity<int>
    {
        public string Name { get; set; } = default;

    }

}

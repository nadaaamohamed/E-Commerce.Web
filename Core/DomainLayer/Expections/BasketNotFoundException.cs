﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Expections
{
    public sealed class BasketNotFoundException(string id) : NotFoundException($"Basket with id: {id} not found")   
    {
    }
}

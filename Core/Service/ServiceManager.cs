using AutoMapper;
using DomainLayer.Contarcts;
using DomainLayer.Models;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUintOfWork unitOfWork , IMapper mapper) : IServiceManager
    {
        private readonly Lazy<ProductService> LazyProductService=new Lazy<ProductService> (() => new ProductService(unitOfWork, mapper));
        public IProductService productService => LazyProductService.Value;
    }
}

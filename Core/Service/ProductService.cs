using AutoMapper;
using DomainLayer.Contarcts;
using DomainLayer.Expections;
using DomainLayer.Models.ProductsModule;
using Service.Speceifications;
using ServiceAbstraction;
using Shared;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class ProductService(IUintOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync() 
        { 
            var Repo=_unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await Repo.GetAllAsync();
            var brandDtos = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable <BrandDto>>(brands);
            return brandDtos;

        }

        public async Task<PaginatedResult<ProductDto>> GetProductsAsync(ProductQueryParams QueryParams)
        {
            var Repo = _unitOfWork.GetRepository<Product, int>();
            var Specifications = new ProductWithBrandAndTypeSpeceificatio(QueryParams);
            var Products = await Repo.GetAllAsync(Specifications);
            var Data= _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
            var productCount=Data.Count();
            var CountSpec = new ProductCountSpeceification(QueryParams);
            var TotalCount =await Repo.CountAsync(CountSpec);
            return new PaginatedResult<ProductDto>(QueryParams.PageIndex, productCount, TotalCount, Data );
           
        }
       

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Type =await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
             return _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Type);
           
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var Specifications = new ProductWithBrandAndTypeSpeceificatio(id);
            var product =await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(Specifications);
            if(product == null)
            {
                throw new ProductNotFoundException(id);
            }
            
                
            return _mapper.Map<Product, ProductDto>(product);
        }

        
    }
}

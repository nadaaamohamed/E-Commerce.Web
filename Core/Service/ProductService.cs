using AutoMapper;
using DomainLayer.Contarcts;
using DomainLayer.Models;
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

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(int ? BrandId , int ? TypeId , ProductSortingOptions sortingOptions)
        {
            var Specifications = new ProductWithBrandAndTypeSpeceificatio(BrandId , TypeId , sortingOptions);
            var Products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(Specifications);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Type =await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
             return _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Type);
           
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product =await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            return _mapper.Map<Product, ProductDto>(product);
        }

        
    }
}

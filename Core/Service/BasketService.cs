using AutoMapper;
using DomainLayer.Contarcts;
using DomainLayer.Expections;
using DomainLayer.Models.BasketModule;
using ServiceAbstraction;
using Shared.DataTransferObject.BasketModulesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BasketService(IBasketRepository _basketRepository , IMapper _mapper) : IBasketService
    {
        public async Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket)
        {
            var customerBasket = _mapper.Map<BasketDto, CustomerBasket>(basket);
            var result =await _basketRepository.CreateOrUpdateBasketAsync(customerBasket);
            if (result is not null)
                return await GetBasketAsync(basket.Id);
            else
                throw new Exception("Error in creating or updating the basket");

        }

        public async Task<bool> DeleteBasketAsync(string Key)
        {
           return await _basketRepository.DeleteBasketAsync(Key);
        }

        public async Task<BasketDto> GetBasketAsync(string Key)
        {
            var Basket=await _basketRepository.GetBasketAsync(Key);
            if(Basket is not null)
                return _mapper.Map<CustomerBasket , BasketDto>(Basket);
            else
                throw new  BasketNotFoundException(Key);
        }
    }
}

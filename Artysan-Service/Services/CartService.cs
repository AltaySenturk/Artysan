using Artysan_Entities.Entites;
using Artysan_Entities.Interfaces;
using Artysan_Entities.UnitOfWorks;
using Artysan_Entities.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artysan_Entities.Entites;

namespace Artysan_Service.Services
{
    public class CartService : ICartService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CartService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<CartViewModel>> AddToCart(List<CartViewModel> cart, CartViewModel cartItem)
        {
            cartItem.EventId = Event.Id;
            MovieName = Event.Name;
             = Adet;
            MoviePrice = movie.Price;
            var newCart = new List<CartViewModel>(_mapper.Map<List<CartViewModel>>(cart));
            var existingCartItem = newCart.Find(c => c.EventId == cartItem.EventId);

            if (existingCartItem != null)
            {
                // If the item already exists in the cart, increment the quantity
                existingCartItem.EventQuantity += cartItem.EventQuantity;
            }
            else
            {
                // If the item doesn't exist in the cart, add the new cartItem
                newCart.Add(cartItem);
            }

            // Return the updated cart
            return newCart;
        }

        public List<CartViewModel> DeleteFromCart(List<CartViewModel> cart, int id)
        {
            cart.RemoveAll(c => c.EventId == id);
            return cart;
        }

        public decimal TotalPrice(List<CartViewModel> cart)
        {
            decimal total = cart.Sum(c => c.EventQuantity * c.EventPrice);
            return total;
        }

        public int TotalQuantity(List<CartViewModel> cart)
        {

            int total = cart.Sum(c => c.EventQuantity);
            return total;
        }
    }


}


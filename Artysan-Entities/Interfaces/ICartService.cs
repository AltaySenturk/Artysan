using Artysan_Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Entities.Interfaces
{
    public interface ICartService
    {
        Task<List<CartViewModel>> AddToCart(List<CartViewModel> cart, CartViewModel cartItem);

        public List<CartViewModel> DeleteFromCart(List<CartViewModel> cart, int id);

        public int TotalQuantity(List<CartViewModel> cart);

        public decimal TotalPrice(List<CartViewModel> cart);


    }
}

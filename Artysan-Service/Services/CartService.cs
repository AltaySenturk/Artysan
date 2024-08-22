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
using Artysan_Entities.Entities;

namespace Artysan_Service.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CartService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<CartViewModel>> AddToCart(List<CartViewModel> cart, CartViewModel cartItem)
        {

            var item = cart.Find(c => c.EventId == cartItem.EventId);
            if (item != null)
            {
                item.EventQuantity += cartItem.EventQuantity;
            }
            else
            {
                cart.Add(cartItem);
            }
            return cart;
        }
        public async Task<TicketViewModel> GetTicket(int Id)
        {
            // Fetch all tickets asynchronously
            var tickets = await _uow.GetRepository<Ticket>().GetByIdAsync(Id);
  
             return _mapper.Map<TicketViewModel>(tickets);

            
       
            /*
            var Ticket = await _uow.GetRepository<Ticket>().GetAll();
            List<CartViewModel> cart = new List<CartViewModel>();
            cart = cart.Where(e => e.Ticket.Id == Id).ToList();
            var eventViewModels = _mapper.Map<List<CartViewModel>>(cart);

            foreach (var eventViewModel in eventViewModels)
            {
                eventViewModel.Ticket = _mapper.Map<TicketViewModel>(
                 Ticket.FirstOrDefault(l => l.Id == eventViewModel.TicketId));
            }
            return eventViewModels;*/
        }
        public List<CartViewModel> DeleteFromCart(List<CartViewModel> cart, int id)
        {
            cart.RemoveAll(c => c.EventId == id);
            return cart;
        }

        public int TotalQuantity(List<CartViewModel> cart)
        {
            int total = cart.Sum(c => c.EventQuantity);
            return total;
        }

        public decimal TotalPrice(List<CartViewModel> cart)
        {
            decimal total = cart.Sum(c => c.EventQuantity * c.EventPrice);
            return total;
        }




    }



}


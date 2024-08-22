using Artysan_Entities.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Entities.ViewModels
{
    public class CartViewModel
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int EventQuantity { get; set; }
        public int EventPrice { get; set; }
        public int Price { get; set; }
        public string EventDate { get; set; }
        public Event Event{ get; set; }
        public int TicketId { get; set; }
         public TicketViewModel Ticket {get; set;}

    
    }
}

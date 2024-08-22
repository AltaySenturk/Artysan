using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.Entites;

namespace Artysan_Entities.Entities
{
    public class Cart
    {
        
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int EventQuantity { get; set; }
        public decimal EventPrice { get; set; }
        public string EventDate { get; set; }
        public Event Event{ get; set; }
         public Ticket Ticket {get; set;}
    }
}
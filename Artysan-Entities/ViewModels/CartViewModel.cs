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
        public decimal EventPrice { get; set; }
        public string EventDate { get; set; }
        public Event Event{ get; set; }
    }
}

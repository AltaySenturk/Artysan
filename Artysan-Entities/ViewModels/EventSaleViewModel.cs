using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artysan_Entities.ViewModels
{
    public class EventSaleViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
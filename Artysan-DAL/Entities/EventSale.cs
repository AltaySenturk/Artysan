using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Artysan_DAL.Entites
{
    public class EventSale
    {
     [Key]
        public int Id { get; set; }
        public string? SalDate { get; set; }
        public int? CustomerId { get; set; }
        public int? TotalQuantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? EventId { get; set; }
       public virtual ICollection<EventSaleDetail> EventSaleDetails { get; set; }


    }
}
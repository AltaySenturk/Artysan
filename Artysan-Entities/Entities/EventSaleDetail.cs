using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Artysan_Entities.Entites
{
    public class EventSaleDetail
    {
         [Key]
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? EventSaleId { get; set; }
        public int? EventId { get; set; }
        public virtual EventSale EventSale { get; set; }

         public virtual Event Event { get; set; }
    }
}
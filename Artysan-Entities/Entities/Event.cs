using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Artysan_Entities.Entites
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EventDate { get; set; }
        public int? TicketId { get; set; }
        public int? Stock { get; set; } 
        public string? ImageUrl { get; set; }
        
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }
        
        public Ticket Ticket { get; set; }
        public virtual IEnumerable<EventSale> EventSales { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Artysan_Entities.Entites
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public string? TicketName { get; set; }
        public decimal Price { get; set; }
   

        public List<Event> Events { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Artysan_DAL.Entites
{
    public class Location
    {
       [Key]
        public int   Id { get; set; }
        public string? Venue { get; set; }
        public string? EventUrl { get; set; }
        public string? LocImageUrl { get; set; }
        public virtual IEnumerable<Event> Events { get; set; }
    }
}
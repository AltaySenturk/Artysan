using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Artysan_Entities.Entites
{
    public class Category
    {
           [Key]
        public int id { get; set; }
        public string? CatName { get; set; }
        public string? CatDescription { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Artysan_DAL.Entites
{
    public class Artist
    {
        
        public int Id { get; set; }
        public string? ArtistName { get; set; }
        public string? ArtistLink { get; set; }
        public string? ArtImageUrl { get; set; }
    }
}
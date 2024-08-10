using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;

namespace Artysan_Entities.ViewModels
{
	public class ArtistViewModel
	{
		public int Id { get; set; }
		public string? ArtistName { get; set; }
		public string? ArtistLink { get; set; }
		public string? ArtImageUrl { get; set; }
	}
}

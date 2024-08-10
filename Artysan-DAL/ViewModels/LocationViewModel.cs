using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_DAL.ViewModels
{
	public class LocationViewModel
	{
		public int Id { get; set; }
		public string? Venue { get; set; }
		public string? EventUrl { get; set; }
		public string? LocImageUrl { get; set; }
	}
}

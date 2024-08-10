using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Service.ViewModels
{
	public class EventViewModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? EventDate { get; set; }
		public int? TicketId { get; set; }
		public int? Stock { get; set; }
		public string? ImageUrl { get; set; }
		public int? CategoryId { get; set; }
		public int? LocationId { get; set; }
		
	}
}

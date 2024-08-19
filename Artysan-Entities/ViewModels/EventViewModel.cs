using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artysan_Entities.Entites;
using Artysan_Entities.Interfaces;

namespace Artysan_Entities.ViewModels
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
		public TicketViewModel Ticket { get; set; }
		public LocationViewModel Location { get; set; }
		
	}
}

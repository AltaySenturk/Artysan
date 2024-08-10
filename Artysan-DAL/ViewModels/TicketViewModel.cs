using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_DAL.ViewModels
{
	public class TicketViewModel
	{
		public int Id { get; set; }
		public string? TicketName { get; set; }
		public decimal? Price { get; set; }

	}
}

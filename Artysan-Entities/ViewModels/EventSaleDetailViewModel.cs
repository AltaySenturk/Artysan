using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;

namespace Artysan_Entities.ViewModels
{
	public class EventSaleDetailViewModel
	{
		public int Id { get; set; }
		public int? Quantity { get; set; }
		public decimal? UnitPrice { get; set; }
		public int? EventSaleId { get; set; }
		public int? EventId { get; set; }
	}
}

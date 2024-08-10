using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;

namespace Artysan_Entities.ViewModels
{
	public class EventArtistViewModel
	{
		public int Id { get; set; }
		public int? EventId { get; set; }
		public int ArtistId { get; set; }

	}
}


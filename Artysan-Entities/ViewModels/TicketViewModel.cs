﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;

namespace Artysan_Entities.ViewModels
{
	public class TicketViewModel
	{
		public int Id { get; set; }
		public string? TicketName { get; set; }
		public decimal Price { get; set; }

	}
}

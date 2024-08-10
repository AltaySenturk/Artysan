using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;

namespace Artysan_Entities.ViewModels
{
	public class CategoryViewModel
	{
		public int id { get; set; }
		public string? CatName { get; set; }
		public string? CatDescription { get; set; }
	}
}

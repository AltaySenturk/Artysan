using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Service.ViewModels
{
	public class CustomerViewModel
	{
		public int Id { get; set; }
		public string? CustomerName { get; set; }
		public string? Surname { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public string? Address { get; set; }
		public string? Phone { get; set; }
	}
}

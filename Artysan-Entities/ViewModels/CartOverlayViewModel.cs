using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artysan_Entities.ViewModels
{
    public class CartOverlayViewModel
    {
        public List<CartViewModel> CartItems { get; set; }
        public int TotalPrice { get; set; }
    }
}
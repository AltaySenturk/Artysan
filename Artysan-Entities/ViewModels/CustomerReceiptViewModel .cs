using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artysan_Entities.ViewModels
{
    public class CustomerReceiptViewModel 
    {
        public UserViewModel  userViewModel { get; set; }
        public EventSaleViewModel  eventSaleViewModel { get; set; }

        public List<CartViewModel>  cartViews { get; set; }
    }
}
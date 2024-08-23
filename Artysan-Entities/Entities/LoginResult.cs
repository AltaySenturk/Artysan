using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.ViewModels;

namespace Artysan_Entities.Entities
{
    public class LoginResult
    {
     public string Status { get; set; }
    public UserViewModel User { get; set; }
    }
}
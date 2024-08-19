using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Entities.ViewModels
{
    public class EditRoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] UsersIdsToAdd { get; set; }
        public string[] UsersIdsToDelete { get; set; }
    }
}

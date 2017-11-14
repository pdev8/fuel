using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel.Models.Request
{
    public class UserRoleUpdateRequest : UserRoleAddRequest
    {
        public int Id { get; set; }
    }
}

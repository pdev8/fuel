using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuel.Models.Request
{
    public class TrainerAddRequest
    {
        public int UserProfileId { get; set; }
        public string Bio { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel.Models.Domain
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserRoleId { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}

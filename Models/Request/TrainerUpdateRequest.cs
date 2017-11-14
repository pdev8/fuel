using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fuel.Models.Request
{
    public class TrainerUpdateRequest : TrainerAddRequest
    {
        public int Id { get; set; }
    }
}
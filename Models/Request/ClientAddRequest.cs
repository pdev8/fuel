using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel.Models.Request
{
    public class ClientAddRequest
    {
        public int UserProfileId { get; set; }
        public int TrainerId { get; set; }
        public int PlanId { get; set; }
    }
}

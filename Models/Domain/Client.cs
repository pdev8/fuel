using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel.Models.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int TrainerId { get; set; }
        public int PlanId { get; set; }
    }
}

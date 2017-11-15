using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel.Models.Domain
{
    public class TrainingLog
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public int SquatMax { get; set; }
        public int BenchMax { get; set; }
        public int DeadliftMax { get; set; }
        public int SquatProgram { get; set; }
        public int BenchProgram { get; set; }
        public int DeadliftProgram { get; set; }
    }
}

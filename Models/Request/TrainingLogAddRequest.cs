using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel.Models.Request
{
    public class TrainingLogAddRequest
    {
        public int Week;
        public int SquatMax;
        public int BenchMax;
        public int DeadliftMax;
        public int SquatProgram;
        public int BenchProgram;
        public int DeadliftProgram;
    }
}

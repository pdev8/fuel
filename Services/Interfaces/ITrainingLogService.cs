using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuel.Models.Domain;
using Fuel.Models.Request;

namespace Fuel.Services.Interfaces
{
    public interface ITrainingLogService
    {
        TrainingLog GetByWeek(int week);
        int Insert(TrainingLogAddRequest model);
        void UpdateByWeek(TrainingLogUpdateRequest model);
        void DeleteByWeek(int week);
    }
}

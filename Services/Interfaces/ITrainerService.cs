using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fuel.Models.Domain;
using Fuel.Models.Request;

namespace Fuel.Services.Interfaces
{
    public interface ITrainerService
    {
        IEnumerable<Trainer> GetAll();
        Trainer GetById(int id);
        int Insert(TrainerAddRequest model);
        void Update(TrainerUpdateRequest model);
        void Delete(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuel.Models.Domain;
using Fuel.Models.Request;

namespace Fuel.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Client> GetAll();
        Client GetById(int id);
        int Insert(ClientAddRequest model);
        void Update(ClientUpdateRequest model);
        void Delete(int id);
    }
}

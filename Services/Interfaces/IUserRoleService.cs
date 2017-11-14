using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuel.Data.Adapter;
using Fuel.Data.Tools;
using Fuel.Models.Domain;
using Fuel.Models.Request;
using Fuel.Services.Services;


namespace Fuel.Services.Interfaces
{
    public interface IUserRoleService
    {
        IEnumerable<UserRole> GetAll();
        UserRole GetById(int id);
        int Insert(UserRoleAddRequest model);
        void Update(UserRoleUpdateRequest model);
        void Delete(int id);
    }
}

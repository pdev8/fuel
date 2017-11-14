using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuel.Models.Domain;
using Fuel.Models.Request;

namespace Fuel.Services.Interfaces
{
    public interface IUserProfileService
    {
        IEnumerable<UserProfile> GetAll();
        UserProfile GetById(int id);
        int Insert(UserProfileAddRequest model);
        void Update(UserProfileUpdateRequest model);
        void DeleteById(int id);
    }
}

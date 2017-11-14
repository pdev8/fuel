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
using Fuel.Services.Interfaces;

namespace Fuel.Services.Services
{
    public class UserProfileService : BaseService, IUserProfileService
    {
        //////////// GET ALL USER PROFILES /////////////
        public IEnumerable<UserProfile> GetAll()
        {
            DbCmdDef cmdDef = new DbCmdDef()
            {
                DbCommandText = "dbo.UserProfile_SelectAll",
                DbCommandType = CommandType.StoredProcedure
            };
            return Adapter.LoadObject<UserProfile>(cmdDef);
        }

        //////////// GET USER PROFILE BY ID /////////////
        public UserProfile GetById(int id)
        {
            try
            {
                return Adapter.LoadObject<UserProfile>(new DbCmdDef()
                {
                    DbCommandText = "dbo.UserProfile_SelectById",
                    DbCommandType = CommandType.StoredProcedure,
                    DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@Id", id, SqlDbType.Int)
                    }
                }).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //////////// INSERT USER PROFILE /////////////
        public int Insert(UserProfileAddRequest model)
        {
            int id = 0;

            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.UserProfile_Insert",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new []
                {
                    SqlDbParameter.Instance.BuildParameter("@FirstName", model.FirstName, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@LastName", model.LastName, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Email", model.Email, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@UserRoleId", model.UserRoleId, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@ProfileImageUrl", model.ProfileImageUrl, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Id", id, SqlDbType.Int, paramDirection: ParameterDirection.Output)
                }
            };

            Adapter.ExecuteQuery(cmdDef, delegate (IDataParameterCollection collection)
            {
                Int32.TryParse(collection["@Id"].ToString(), out id);
            });

            return id;
        }

        //////////// UPDATE USER PROFILE BY ID /////////////
        public void Update(UserProfileUpdateRequest model)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.UserProfile_UpdateById",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@FirstName", model.FirstName, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@LastName", model.LastName, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Email", model.Email, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@UserRoleId", model.UserRoleId, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@ProfileImageUrl", model.ProfileImageUrl, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Id", model.Id, SqlDbType.Int)
                }
            };

            Adapter.ExecuteQuery(cmdDef);
        }

        //////////// DELETE USER PROFILE BY ID /////////////
        public void DeleteById(int id)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.UserProfile_DeleteById",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Id", id, SqlDbType.Int)
                }
            };

            Adapter.ExecuteQuery(cmdDef);
        }
    }
}

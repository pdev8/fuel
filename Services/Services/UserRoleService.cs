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
    public class UserRoleService : BaseService, IUserRoleService
    {
        public IEnumerable<UserRole> GetAll()
        {
            DbCmdDef cmdDef = new DbCmdDef()
            {
                DbCommandText = "dbo.UserRole_SelectAll",
                DbCommandType = CommandType.StoredProcedure
            };
            return Adapter.LoadObject<UserRole>(cmdDef);
        }

        public UserRole GetById(int id)
        {
            try
            {
                return Adapter.LoadObject<UserRole>(new DbCmdDef()
                {
                    DbCommandText = "dbo.UserRole_SelectById",
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

        public int Insert(UserRoleAddRequest model)
        {
            int id = 0;

            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.UserRole_Insert",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Bio", model.RoleType, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Id", id, SqlDbType.Int, paramDirection: ParameterDirection.Output)
                }
            };

            Adapter.ExecuteQuery(cmdDef, delegate (IDbDataParameter[] collection)
            {
                //Int32.TryParse(collection["@Id"].ToString(), out id);
                id = collection.GetParmValue<Int32>("@Id");
            });

            return id;
        }

        public void Update(UserRoleUpdateRequest model)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.UserRole_UpdateById",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@RoleType", model.RoleType, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Id", model.Id, SqlDbType.Int)
                }
            };

            Adapter.ExecuteQuery(cmdDef);
        }

        public void Delete(int id)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.UserRole_DeleteById",
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

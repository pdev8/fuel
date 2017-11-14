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
    public class ClientService : BaseService, IClientService
    {
        //////////// GET ALL CLIENTS /////////////
        public IEnumerable<Client> GetAll()
        {
            DbCmdDef cmdDef = new DbCmdDef()
            {
                DbCommandText = "dbo.Client_SelectAll",
                DbCommandType = CommandType.StoredProcedure
            };
            return Adapter.LoadObject<Client>(cmdDef);
        }

        //////////// GET CLIENTS BY ID /////////////
        public Client GetById(int id)
        {
            try
            {
                return Adapter.LoadObject<Client>(new DbCmdDef()
                {
                    DbCommandText = "dbo.Client_SelectById",
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

        //////////// INSERT CLIENT /////////////
        public int Insert(ClientAddRequest model)
        {
            int id = 0;

            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Client_Insert",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@UserProfileId", model.UserProfileId, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@TrainerId", model.TrainerId, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@PlanId", model.PlanId, SqlDbType.Int),
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
        public void Update(ClientUpdateRequest model)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Client_UpdateById",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@UserProfileId", model.UserProfileId, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@TrainerId", model.TrainerId, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@PlanId", model.PlanId, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@Id", model.Id, SqlDbType.Int)
                }
            };

            Adapter.ExecuteQuery(cmdDef);

        }

        //////////// DELETE USER PROFILE BY ID /////////////
        public void Delete(int id)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Client_DeleteById",
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

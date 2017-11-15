using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Fuel.Data.Adapter;
using Fuel.Data.Tools;
using Fuel.Models.Domain;
using Fuel.Models.Request;
using Fuel.Services.Interfaces;

namespace Fuel.Services.Services
{
    public class TrainerService : BaseService, ITrainerService
    {
        public IEnumerable<Trainer> GetAll()
        {
            DbCmdDef cmdDef = new DbCmdDef()
            {
                DbCommandText = "dbo.Trainer_SelectAll",
                DbCommandType = CommandType.StoredProcedure
            };
            return Adapter.LoadObject<Trainer>(cmdDef);
        }

        public Trainer GetById(int id)
        {
            try
            {
                return Adapter.LoadObject<Trainer>(new DbCmdDef()
                {
                    DbCommandText = "dbo.Trainer_SelectById",
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

        public int Insert(TrainerAddRequest model)
        {
            int id = 0;

            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Trainer_Insert",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Bio", model.Bio, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@UserProfileId", model.UserProfileId, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@FirstName", model.FirstName, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@LastName", model.LastName, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Email", model.Email, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Gender", model.Gender, SqlDbType.NVarChar),
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

        public void Update(TrainerUpdateRequest model)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Trainer_UpdateById",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Bio", model.Bio, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@UserProfileId", model.UserProfileId, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@FirstName", model.FirstName, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@LastName", model.LastName, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Email", model.Email, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Gender", model.Gender, SqlDbType.NVarChar),
                    SqlDbParameter.Instance.BuildParameter("@Id", model.Id, SqlDbType.Int)
                }
            };

            Adapter.ExecuteQuery(cmdDef);
        }

        public void Delete(int id)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.Trainer_DeleteById",
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
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
    public class TrainingLogService : BaseService, ITrainingLogService
    {
        public TrainingLog GetByWeek(int week)
        {
            try
            {
                return Adapter.LoadObject<TrainingLog>(new DbCmdDef()
                {
                    DbCommandText = "dbo.TrainingLog_SelectByWeek",
                    DbCommandType = CommandType.StoredProcedure,
                    DbParameters = new[]
                    {
                        SqlDbParameter.Instance.BuildParameter("@Week", week, SqlDbType.Int)
                    }
                }).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public int Insert(TrainingLogAddRequest model)
        {
            int id = 0;

            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.TrainingLog_Insert",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Week", model.Week, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@SquatMax", model.SquatMax, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@BenchMax", model.BenchMax, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@DeadliftMax", model.DeadliftMax, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@SquatProgram", model.SquatProgram, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@BenchProgram", model.BenchProgram, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@DeadliftProgram", model.DeadliftProgram, SqlDbType.Int),
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

        public void UpdateByWeek(TrainingLogUpdateRequest model)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.TrainingLog_UpdateByWeek",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Week", model.Week, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@SquatMax", model.SquatMax, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@BenchMax", model.BenchMax, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@DeadliftMax", model.DeadliftMax, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@SquatProgram", model.SquatProgram, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@BenchProgram", model.BenchProgram, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@DeadliftProgram", model.DeadliftProgram, SqlDbType.Int),
                    SqlDbParameter.Instance.BuildParameter("@Id", model.Id, SqlDbType.Int)
                }
            };

            Adapter.ExecuteQuery(cmdDef);

        }

        public void DeleteByWeek(int week)
        {
            DbCmdDef cmdDef = new DbCmdDef
            {
                DbCommandText = "dbo.TrainingLog_DeleteByWeek",
                DbCommandType = CommandType.StoredProcedure,
                DbParameters = new[]
                {
                    SqlDbParameter.Instance.BuildParameter("@Week", week, SqlDbType.Int)
                }
            };

            Adapter.ExecuteQuery(cmdDef);
        }
    }
}

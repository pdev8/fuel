using System;
using System.Collections.Generic;
using System.Data;

namespace Fuel.Data.Adapter
{
    public interface IDbAdapter
    {
        IDbCommand DbCommand { get; }
        IDbConnection DbConnection { get; }
        int CommandTimeout { get; set; }
        IEnumerable<T> LoadObject<T>(IDbCmdDef cmdDef) where T : class;
        IEnumerable<T> LoadObject<T>(IDbCmdDef cmdDef, Func<IDataReader, T> mapper) where T : class;
        int ExecuteQuery(IDbCmdDef cmdDef, Action<IDbDataParameter[]> returnParameters = null);
        object ExecuteScalar(IDbCmdDef cmdDef);

    }
}
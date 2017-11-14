using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuel.Data.Tools;

namespace Fuel.Data.Adapter
{
    public class DbAdapter : IDbAdapter
    {
        // Only sets the set to private, get is still public
        public IDbCommand DbCommand { get; private set; }

        public IDbConnection DbConnection { get; private set; }

        // Timeout
        int _cmdTimeout = 5000;

        public int CommandTimeout
        {
            get { return _cmdTimeout; }
            set { _cmdTimeout = value; }
        }

        public DbAdapter(IDbCommand dbCommand, IDbConnection dbConnection)
        {
            DbCommand = dbCommand;
            DbConnection = dbConnection;
        }

        // Select
        // We're telling T that T is only a class (generic)
        // Interface for a list - IEnumerable<T>
        // Return of a list of generics (LoadObject -> pulling data)
        public IEnumerable<T> LoadObject<T>(IDbCmdDef cmdDef) where T : class
        {
            try
            {
                if (cmdDef == null)
                    throw new ArgumentException("Missing command definition");

                List<T> itms = new List<T>();
                // Gives us a (built in) try, catch, finally (trash collector)
                // ADO.NET
                using (IDbConnection conn = DbConnection)
                using (IDbCommand cmd = DbCommand)
                {
                    if (conn.State != ConnectionState.Open)
                        // Makes sure that we have a open connection (to the db) all the time
                        conn.Open();

                    // What you want to send through the conection
                    // If you go past the timeout time you will timeout
                    cmd.CommandTimeout = CommandTimeout;
                    cmd.CommandType = cmdDef.DbCommandType;
                    cmd.CommandText = cmdDef.DbCommandText;
                    // Assign a connection to a command
                    cmd.Connection = conn;

                    // Whatever called this method, were there any parameters?
                    if (cmdDef.DbParameters != null)
                        foreach (IDbDataParameter param in cmdDef.DbParameters)
                            cmd.Parameters.Add(param);

                    // ExecuteReader() - take all info and execute it
                    // Why? - forward looking (streams it all out one at a time) and does not go backwards
                    IDataReader reader = cmd.ExecuteReader();
                    // While it's reading each row, it'll add to a list
                    while (reader.Read())
                    {
                        // TODO: Build Data Mapper
                        itms.Add(DataMapper<T>.Instance.MapToObject(reader));
                    }
                    return itms;
                }
            }
            catch
            {
                throw;
            }
        }

        // Function delegate (take a data reader in and output an object)
        public IEnumerable<T> LoadObject<T>(IDbCmdDef cmdDef, Func<IDataReader, T> mapper) where T : class
        {
            try
            {
                if (cmdDef == null)
                    throw new ArgumentException("Missing command definition");

                List<T> itms = new List<T>();
                // Gives us a (built in) try, catch, finally (trash collector)
                // ADO.NET
                using (IDbConnection conn = DbConnection)
                using (IDbCommand cmd = DbCommand)
                {
                    if (conn.State != ConnectionState.Open)
                        // Makes sure that we have a open connection (to the db) all the time
                        conn.Open();

                    // What you want to send through the conection
                    cmd.CommandTimeout = CommandTimeout;
                    cmd.CommandType = cmdDef.DbCommandType;
                    cmd.CommandText = cmdDef.DbCommandText;
                    // Assign a connection to a command
                    cmd.Connection = conn;

                    // Whatever called this method, were there any parameters?
                    if (cmdDef.DbParameters != null)
                        foreach (IDbDataParameter param in cmdDef.DbParameters)
                            cmd.Parameters.Add(param);

                    // ExecuteReader() - take all info and execute it
                    IDataReader reader = cmd.ExecuteReader();
                    // While it's reading each row, it'll add to a list
                    while (reader.Read())
                    {
                        // TODO: Build Data Mapper
                        itms.Add(mapper(reader));
                    }
                    return itms;
                }
            }
            catch
            {
                throw;
            }
        }

        // Insert, Update, Delete
        public int ExecuteQuery(IDbCmdDef cmdDef, Action<IDataParameterCollection> returnParameters = null)
        {
            try
            {
                using (IDbConnection conn = DbConnection)
                using (IDbCommand cmd = DbCommand)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    cmd.CommandTimeout = CommandTimeout;
                    cmd.CommandType = cmdDef.DbCommandType;
                    cmd.CommandText = cmdDef.DbCommandText;
                    cmd.Connection = conn;

                    if (cmdDef.DbParameters != null)
                        foreach (IDbDataParameter param in cmdDef.DbParameters)
                            cmd.Parameters.Add(param);

                    int returnVal = cmd.ExecuteNonQuery();
                    // If it exists, do this this
                    returnParameters?.Invoke(cmd.Parameters);

                    return returnVal;
                }
            }
            catch
            {
                throw;
            }
        }

        // To handle returns from SQL (return 1 recond 1 column)
        public object ExecuteScalar(IDbCmdDef cmdDef)
        {
            try
            {
                using (IDbConnection conn = DbConnection)
                using (IDbCommand cmd = DbCommand)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    cmd.CommandTimeout = CommandTimeout;
                    cmd.CommandType = cmdDef.DbCommandType;
                    cmd.CommandText = cmdDef.DbCommandText;
                    cmd.Connection = conn;

                    if (cmdDef.DbParameters != null)
                        foreach (IDbDataParameter param in cmdDef.DbParameters)
                            cmd.Parameters.Add(param);

                    return cmd.ExecuteScalar();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

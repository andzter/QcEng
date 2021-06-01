using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace QC.Lib
{
    public class DataAccess
    {
        private string _connectionString = Settings.GetSetting("ConnectionString");
        private string _errmsg = string.Empty;
        private string _providername = "System.Data.SqlClient";

        private int _timeout = 1200;

        public DataAccess()
        {

        }

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ErrorMessage
        {
            get
            {
                return _errmsg;
            }
        }

        public object ExecSQLScalarSP(string storedProc, params object[] args)
        {
            _errmsg = string.Empty;
            object result = null; ;
            SqlDatabase sqlDb;
            DbCommand dbCommand = null;

            sqlDb = new SqlDatabase(_connectionString);

            try
            {
                dbCommand = sqlDb.GetStoredProcCommand(storedProc, args);
                dbCommand.CommandTimeout = _timeout;
                result = sqlDb.ExecuteScalar(dbCommand);
            }
            catch (Exception ex)
            {
                _errmsg = $"Error in  ExecSQLScalarSP {storedProc} \nError Message:{ex.Message}";
                //throw new Exception("Error in  ExecSQLScalarSP :" + storedProc + "\nError Message:" + ex.Message);
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection.State == ConnectionState.Open)
                        dbCommand.Connection.Close();
                }
            }
            return result;
        }

        public int ExecuteSql(string commandText)
        {
            int i = -1;
            _errmsg = string.Empty;
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(_providername);

                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = _connectionString;
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = commandText;
                        connection.Open();
                        command.CommandTimeout = _timeout;
                        i = command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                _errmsg = $"ExecuteSql Error : {commandText} \nError Message:{ex.Message}";
                //throw new Exception("ExecuteSql error : " + ex.Message + "\nSQL:" + commandText);
            }
            return i;

        }


        public DataSet GetDataSet(string sql)
        {

            _errmsg = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                DbProviderFactory factory = DbProviderFactories.GetFactory(_providername);

                using (DbConnection conn = factory.CreateConnection())
                {
                    conn.ConnectionString = _connectionString;

                    using (DbDataAdapter adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = conn.CreateCommand();
                        adapter.SelectCommand.CommandTimeout = 1200;
                        adapter.SelectCommand.CommandText = sql;
                        adapter.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                _errmsg = $"GetDataSet Error : {sql} \nError Message:{ex.Message}";
                //throw new Exception("GetDataSet error : " + ex.Message + "\nSQL:" + sql);
            }
            return null;
        }


        public DataSet GetDataSet(string storedProc, params object[] args)
        {
            DataSet result = null;
            SqlDatabase sqlDb;
            DbCommand dbCommand = null;

            sqlDb = new SqlDatabase(_connectionString);
            _errmsg = string.Empty;
            try
            {
                dbCommand = sqlDb.GetStoredProcCommand(storedProc, args);
                dbCommand.CommandTimeout = _timeout;
                result = sqlDb.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                _errmsg = $"GetDataSet Error : {storedProc} \nError Message:{ex.Message}";
                //throw new Exception("Error in  GetDataSet(string storedProc, params object[] args) :" + ex.Message + "\nSP:" + storedProc);
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection.State == ConnectionState.Open)
                        dbCommand.Connection.Close();
                }
            }
            return result;
        }

        public string ExcelOut(DataSet ds)
        {
            if (ds != null)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbRow = new StringBuilder();
                int j = 0, i = 0;
                DataRow dr;
                for (i = 0; i < ds.Tables[0].Columns.Count; i++)
                    sb.Append((i != 0 ? "\t" : "") + ds.Tables[0].Columns[i].Caption.ToString());

                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sbRow = new StringBuilder();
                    dr = ds.Tables[0].Rows[i];
                    for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                        sbRow.Append((j != 0 ? "\t" : "") + dr[j]);
                    sb.AppendLine();
                    sb.Append(sbRow.ToString());
                }
                return sb.ToString();
            }
            return "";
        }

        public string ExcelOut(string strSQL)
        {
            return ExcelOut(GetDataSet(strSQL));
        }

        public DataRow GetDataRow(string strSQL)
        {
            DataRow dr = null;
            DataSet ds = GetDataSet(strSQL);
            if (ds != null)
                if (ds.Tables[0].Rows.Count > 0) dr = ds.Tables[0].Rows[0];
            return dr;
        }


        public DataTable GetDataTable(string query)
        {
            return GetDataSet(query).Tables[0];
        }

        public DataTable GetDataTable(string storedProc, params object[] args)
        {
            return GetDataSet(storedProc, args).Tables[0];
        }

        public DataRow GetDataRow(string storedProc, params object[] args)
        {
            DataTable dt = GetDataSet(storedProc, args).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        public int ExecuteNonQuery(string storedProc, params object[] args)
        {
            int result = -1;
            SqlDatabase sqlDb;
            DbCommand dbCommand = null;

            sqlDb = new SqlDatabase(_connectionString);
            _errmsg = string.Empty;
            try
            {
                dbCommand = sqlDb.GetStoredProcCommand(storedProc, args);
                dbCommand.CommandTimeout = _timeout;
                result = sqlDb.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                _errmsg = $"ExecuteNonQuery Error : {storedProc} \nError Message:{ex.Message}";
                //throw new Exception("Error in  ExecuteNonQuery :" + ex.Message);
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection.State == ConnectionState.Open)
                        dbCommand.Connection.Close();
                }
            }
            return result;
        }

        public List<T> GetListTotalRows<T>( string storedProc, out int totalRows, params object[] args) where T : IDBPersist, new()
        {
            totalRows = 0;
            List<T> items = new List<T>();
            SqlDatabase sqlDb = null;
            DbCommand dbCommand = null;
            sqlDb = new SqlDatabase(_connectionString);

            try
            {
                object[] argsWithRows = new object[args.Length + 1];
                for (int i = 0; i < args.Length; i++)
                {
                    argsWithRows[i] = args[i];
                }
                argsWithRows[args.Length] = totalRows;

                dbCommand = sqlDb.GetStoredProcCommand(storedProc, argsWithRows);
                dbCommand.CommandTimeout = _timeout;

                using (IDataReader rdr = sqlDb.ExecuteReader(dbCommand))
                {
                    while (rdr.Read())
                    {
                        T item = new T();
                        item.PersistFromDatabase(rdr);
                        items.Add(item);
                    }
                }
                totalRows = (int)sqlDb.GetParameterValue(dbCommand, "TotalRows");
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection.State == ConnectionState.Open)
                        dbCommand.Connection.Close();
                }
            }

            return items;
        }

        public List<T> GetList<T> (string storedProc, params object[] args) where T : IDBPersist, new()
        {
            List<T> items = new List<T>();
            SqlDatabase sqlDb = null;
            DbCommand dbCommand = null;

            sqlDb = new SqlDatabase(_connectionString);

            try
            {

                dbCommand = sqlDb.GetStoredProcCommand(storedProc, args);
                dbCommand.CommandTimeout = _timeout;
                using (IDataReader rdr = sqlDb.ExecuteReader(dbCommand))
                {
                    while (rdr.Read())
                    {
                        T item = new T();
                        item.PersistFromDatabase(rdr);
                        items.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection.State == ConnectionState.Open)
                        dbCommand.Connection.Close();
                }
            }

            return items;

        }

        public T GetObject<T>( string storedProc, params object[] args) where T : IDBPersist, new()
        {
            T item = new T();
            SqlDatabase sqlDb = null;
            DbCommand dbCommand = null;

            sqlDb = new SqlDatabase(_connectionString);

            try
            {
                dbCommand = sqlDb.GetStoredProcCommand(storedProc, args);
                dbCommand.CommandTimeout = _timeout;
                using (IDataReader rdr = sqlDb.ExecuteReader(dbCommand))
                {
                    if (rdr.Read())
                        item.PersistFromDatabase(rdr);
                }
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection.State == ConnectionState.Open)
                        dbCommand.Connection.Close();
                }
            }

            return item;
        }




        public void CopyData(DataTable sourceTable, SqlConnection destConnection, string desttablename, string mappingFrom, string mappingTo)
        {
            // new method: SQLBulkCopy:
            using (SqlBulkCopy s = new SqlBulkCopy(destConnection))
            {
                s.DestinationTableName = desttablename;
                s.BulkCopyTimeout = _timeout;
                //s.NotifyAfter = 10000;
                //s.SqlRowsCopied += new SqlRowsCopiedEventHandler(s_SqlRowsCopied);

                string[] colFrom = mappingFrom.Split(',');
                string[] colTo = mappingTo.Split(',');

                for (int i = 0; i < colTo.Length; i++)
                {
                    s.ColumnMappings.Add(colFrom[i], colTo[i]);
                    //s.ColumnMappings.Add("CarrierTrackingNumber", "TrackingNumber");
                }

                s.WriteToServer(sourceTable);
                s.Close();
            }
        }


    }
}

using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Configuration;
using System.Diagnostics;
using System.Web;

namespace SouthNests.Phoenix.Framework
{
    /// <summary>
    /// Summary description for txtdataaccess
    /// </summary>
    [Serializable]
    public class TxnDataaccess
    {
        TransactionOptions tranOption;
        TransactionScope scope;
        SqlConnection conn;

        public TxnDataaccess()
        {
            
            tranOption = new TransactionOptions();
            tranOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            scope = new TransactionScope(TransactionScopeOption.Required, tranOption);
            conn = new SqlConnection(DataAccess.GetConnectionString());
            conn.Open();
        }

        ///<summary>Executes a stored proc and returns resultset in a DataSet object</summary>
        ///<param name="ProcedureName">Stored Procedure name.</param>
        ///<param name="Parameters">Collection of SqlParameter objects</param>
        ///<returns>DataSet: Resultset returned as a DataTable object</returns>
        public DataSet ExecSPReturnDataSet(string ProcedureName, List<SqlParameter> Parameters)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(ProcedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                CollectParameters(cmd, Parameters);
                da.SelectCommand = cmd;
                da.Fill(ds);
                CollectOutputParameters(cmd, Parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }
            return ds;
        }

        ///<summary>Executes a stored proc and returns int</summary>
        ///<param name="ProcedureName">Stored Procedure name.</param>
        ///<param name="Parameters">Collection of SqlParameter objects</param>
        ///<returns>int: int returned</returns>
        public int ExecSPReturnInt(string ProcedureName, List<SqlParameter> Parameters)
        {
            SqlCommand cmd;
            int i;

            try
            {
                cmd = new SqlCommand(ProcedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                CollectParameters(cmd, Parameters);
                i = cmd.ExecuteNonQuery();
                CollectOutputParameters(cmd, Parameters);
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }
        }

        ///<summary>Executes a stored proc and returns a collection of parameters</summary>
        ///<param name="ProcedureName">Stored Procedure name.</param>
        ///<param name="Parameters">Collection of SqlParameter objects</param>
        ///<returns>SqlParameterCollection: Collection of Input/Output parameters returned</returns>
        public List<SqlParameter> ExecSPReturnParameter(string ProcedureName, List<SqlParameter> Parameters)
        {
            SqlCommand cmd;
            int i;

            try
            {
                cmd = new SqlCommand(ProcedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                CollectParameters(cmd, Parameters);
                i = cmd.ExecuteNonQuery();
                CollectOutputParameters(cmd, Parameters);
                return Parameters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }
        }

        ///<summary>Get the Connection String from the Web.Config</summary>
        ///<returns>string: Database connection string</returns>
        private string GetConnectionString()
        {
            try
            {
                if (HttpContext.Current.Session["CURRENTDATABASE"] == null)
                    return ConfigurationManager.AppSettings.Get("ConnectionString").ToString();

                return ConfigurationManager.AppSettings.Get("TestConnectionString").ToString() + HttpContext.Current.Session["CURRENTDATABASE"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>Create and Return a SqlParameter</summary>
        ///<param name="ParameterName">Name of the stored procedure parameter</param>
        ///<param name="dbType">SqlParameter data type</param>
        ///<param name="size">size of the parameter</param>
        ///<param name="direction">Parameter Direction Input/Output/InputOutput</param>
        ///<param name="value">value of the parameter</param>
        ///<returns>SqlParameter: SqlParameter created with the specified values</returns>
        public SqlParameter GetDBParameter(string ParameterName, SqlDbType dbType, int size, ParameterDirection direction, object value)
        {
            SqlParameter param;

            param = new SqlParameter(ParameterName, dbType, size);
            param.Direction = direction;
            param.Value = value;

            return param;
        }

        ///<summary>Adds the Parameters from the collection to the Command Object</summary>
        ///<param name="cmd">Command Object</param>
        ///<param name="Parameters">Collection of SqlParameters passed to the Stored Procedure</param>
        ///<returns>void: no return value</returns>
        private void CollectParameters(SqlCommand cmd, List<SqlParameter> Parameters)
        {
            foreach (SqlParameter p in Parameters)
                cmd.Parameters.Add(p);
        }

        ///<summary>Reads the output parameters returned by the stored procedure</summary>
        ///<param name="cmd">Command Object</param>
        ///<param name="Parameters">Collection of SqlParameters passed to the Stored Procedure will include the output parameters</param>
        ///<returns>void: no return value</returns>
        private void CollectOutputParameters(SqlCommand cmd, List<SqlParameter> Parameters)
        {
            foreach (SqlParameter sp in Parameters)
            {
                if (sp.Direction == ParameterDirection.Output)
                {
                    sp.Value = cmd.Parameters[sp.ParameterName].Value;
                }
            }
        }

        ~TxnDataaccess()
        {
            conn.Close();
            conn.Dispose();
            scope.Dispose();
            scope = null;
        }
    }
}
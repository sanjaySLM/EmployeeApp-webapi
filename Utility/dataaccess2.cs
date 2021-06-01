using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace SouthNests.Phoenix.Framework
{
    public class DataAccess2
    {
        ///<summary>Executes a stored proc and returns resultset in a DataSet object</summary>
        ///<param name="ProcedureName">Stored Procedure name.</param>
        ///<param name="Parameters">Collection of SqlParameter objects</param>
        ///<returns>DataSet: Resultset returned as a DataTable object</returns>
        public static DataSet ExecSPReturnDataSet(string ProcedureName, List<SqlParameter> Parameters)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccess2.GetConnectionString()))
                {
                    conn.Open();
                    cmd = new SqlCommand(ProcedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    CollectParameters(cmd, Parameters);
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    CollectOutputParameters(cmd, Parameters);
                }
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
        public static int ExecSPReturnInt(string ProcedureName, List<SqlParameter> Parameters)
        {
            SqlCommand cmd;
            int i = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccess2.GetConnectionString()))
                {
                    conn.Open();
                    cmd = new SqlCommand(ProcedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    CollectParameters(cmd, Parameters);
                    i = cmd.ExecuteNonQuery();
                    CollectOutputParameters(cmd, Parameters);
                }
            }
            catch (SqlException sqlex)
            {
                if (!(sqlex.State == 127 && sqlex.Procedure.StartsWith("TR")))
                    throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }
            return i;
        }

        ///<summary>Executes a stored proc and returns a collection of parameters</summary>
        ///<param name="ProcedureName">Stored Procedure name.</param>
        ///<param name="Parameters">Collection of SqlParameter objects</param>
        ///<returns>SqlParameterCollection: Collection of Input/Output parameters returned</returns>
        public static List<SqlParameter> ExecSPReturnParameter(string ProcedureName, List<SqlParameter> Parameters)
        {
            SqlCommand cmd;
            int i;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccess2.GetConnectionString()))
                {
                    conn.Open();
                    cmd = new SqlCommand(ProcedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    CollectParameters(cmd, Parameters);
                    i = cmd.ExecuteNonQuery();
                    CollectOutputParameters(cmd, Parameters);
                }
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
        public static DataTable ExecSPReturnDataTable(string ProcedureName, List<SqlParameter> Parameters)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccess2.GetConnectionString()))
                {
                    conn.Open();
                    cmd = new SqlCommand(ProcedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (Parameters != null)
                    {
                        CollectParameters(cmd, Parameters);
                        da.SelectCommand = cmd;
                    }
                    else
                    {
                        da.SelectCommand = cmd;
                    }
                    da.Fill(ds);

                    if (Parameters != null)
                    {
                        CollectOutputParameters(cmd, Parameters);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }
            return ds.Tables[0];
        }

        ///<summary>Executes stored procedure in a transaction and returns a Dataset with multiple Tables</summary>
        ///<param name="SpsToExecute">Generic List of Stored Procedures and its parameters to execute.</param>
        ///<returns>DataSet: One or more data tables returned by execution of procedures</returns>
        public static DataSet TxnExecSPReturnDataSet(string ProcedureName, List<SqlParameter> Parameters)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;

            try
            {
                TransactionOptions tranOption;
                tranOption = new TransactionOptions();
                tranOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, tranOption))
                {
                    using (SqlConnection conn = new SqlConnection(DataAccess2.GetConnectionString()))
                    {
                        conn.Open();
                        cmd = new SqlCommand(ProcedureName, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        CollectParameters(cmd, Parameters);
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        CollectOutputParameters(cmd, Parameters);
                    }
                    scope.Complete();
                }
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

        ///<summary>Executes a stored procedure in a transaction and returns a Dataset with multiple Tables</summary>
        ///<param name="SpsToExecute">Generic List of Stored Procedures and its parameters to execute.</param>
        ///<returns>DataSet: One or more data tables returned by execution of procedures</returns>
        public static int TxnExecSPReturnInt(string ProcedureName, List<SqlParameter> Parameters)
        {
            SqlCommand cmd;
            int i = 0;

            try
            {
                TransactionOptions tranOption;
                tranOption = new TransactionOptions();
                tranOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, tranOption))
                {
                    using (SqlConnection conn = new SqlConnection(DataAccess2.GetConnectionString()))
                    {
                        conn.Open();
                        cmd = new SqlCommand(ProcedureName, conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        CollectParameters(cmd, Parameters);
                        i = cmd.ExecuteNonQuery();
                        CollectOutputParameters(cmd, Parameters);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }
            return i;
        }

        ///<summary>Executes one or more stored procedurece in a transaction and returns a Dataset with multiple Tables</summary>
        ///<param name="SpsToExecute">Generic List of Stored Procedures and its parameters to execute.</param>
        ///<returns>DataSet: One or more data tables returned by execution of procedures</returns>
        public static DataSet TxnExecMultipleSPReturnDataSet(List<SPCollectionItem> SpsToExecute)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;

            try
            {
                TransactionOptions tranOption;
                tranOption = new TransactionOptions();
                tranOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, tranOption))
                {
                    using (SqlConnection conn = new SqlConnection(DataAccess2.GetConnectionString()))
                    {
                        conn.Open();

                        foreach (SPCollectionItem spci in SpsToExecute)
                        {
                            cmd = new SqlCommand(spci.ProcedureName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            CollectParameters(cmd, spci.Parameters);
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            ds.Tables.Add(dt);
                            CollectOutputParameters(cmd, spci.Parameters);
                        }
                    }
                    scope.Complete();
                }
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

        ///<summary>Executes one or more stored procedurece in a transaction and returns a Dataset with multiple Tables</summary>
        ///<param name="SpsToExecute">Generic List of Stored Procedures and its parameters to execute.</param>
        ///<returns>DataSet: One or more data tables returned by execution of procedures</returns>
        public static int TxnExecMultipleSPReturnInt(List<SPCollectionItem> SpsToExecute)
        {
            SqlCommand cmd;
            int i = 0;

            try
            {
                TransactionOptions tranOption;
                tranOption = new TransactionOptions();
                tranOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, tranOption))
                {
                    using (SqlConnection conn = new SqlConnection(DataAccess2.GetConnectionString()))
                    {
                        conn.Open();

                        foreach (SPCollectionItem spci in SpsToExecute)
                        {
                            cmd = new SqlCommand(spci.ProcedureName, conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            CollectParameters(cmd, spci.Parameters);
                            i = cmd.ExecuteNonQuery();
                            CollectOutputParameters(cmd, spci.Parameters);
                        }
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }
            return i;
        }

        ///<summary>Get the Connection String from the Web.Config</summary>
        ///<returns>string: Database connection string</returns>
        public static string GetConnectionString()
        {
            try
            {
                //if(HttpContext.Current.Session["CURRENTDATABASE"] == null)
                return ConfigurationManager.ConnectionStrings[2].ToString();

                //return ConfigurationManager.AppSettings.Get("TestConnectionString").ToString() + HttpContext.Current.Session["CURRENTDATABASE"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        /// <param name="precision"></param>
        /// <param name="scale"></param>
        /// <param name="value"></param>
        /// <returns></returns>        
        public static SqlParameter GetDBParameter(string ParameterName, SqlDbType dbType, int size, ParameterDirection direction, byte precision, byte scale, object value)
        {
            SqlParameter param;

            param = new SqlParameter(ParameterName, dbType, size);
            param.Precision = precision;
            param.Scale = scale;
            param.Direction = direction;
            param.Value = value;

            return param;
        }

        ///<summary>Create and Return a SqlParameter</summary>
        ///<param name="ParameterName">Name of the stored procedure parameter</param>
        ///<param name="dbType">SqlParameter data type</param>
        ///<param name="size">size of the parameter</param>
        ///<param name="direction">Parameter Direction Input/Output/InputOutput</param>
        ///<param name="value">value of the parameter</param>
        ///<returns>SqlParameter: SqlParameter created with the specified values</returns>
        public static SqlParameter GetDBParameter(string ParameterName, SqlDbType dbType, int size, ParameterDirection direction, object value)
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
        public static void CollectParameters(SqlCommand cmd, List<SqlParameter> Parameters)
        {
            foreach (SqlParameter p in Parameters)
                cmd.Parameters.Add(p);
        }

        ///<summary>Reads the output parameters returned by the stored procedure</summary>
        ///<param name="cmd">Command Object</param>
        ///<param name="Parameters">Collection of SqlParameters passed to the Stored Procedure will include the output parameters</param>
        ///<returns>void: no return value</returns>
        public static void CollectOutputParameters(SqlCommand cmd, List<SqlParameter> Parameters)
        {
            foreach (SqlParameter sp in Parameters)
            {
                if (sp.Direction == ParameterDirection.Output)
                {
                    sp.Value = cmd.Parameters[sp.ParameterName].Value;
                }
            }
        }
    }
}

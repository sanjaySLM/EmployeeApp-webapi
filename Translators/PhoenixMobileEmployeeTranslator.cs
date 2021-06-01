using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SouthNests.Phoenix.Framework;
using System.Web.Script.Serialization;
using SouthNests.PhoenixMobile.Model;

namespace SouthNests.PhoenixMobile.Translators
{
    public class PhoenixMobileEmployeeTranslator
    {

        public static List<EmployeeListModel> ListEmployee(string name)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> ParameterList = new List<SqlParameter>();

            dt = DataAccess.ExecSPReturnDataTable("PREMPLOYEEDETAILLIST", ParameterList);

            return EmployeeListModel.TranslateAsEmployeeList(dt);

        }
       

        public static List<EmployeeSearchModel> ListSearching(EmployeeSearch model)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> ParameterList = new List<SqlParameter>();

            ParameterList.Add(DataAccess.GetDBParameter("@EMPLOYEENAME", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.employeeName));
            ParameterList.Add(DataAccess.GetDBParameter("@SORTBY", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.sortBy));
            ParameterList.Add(DataAccess.GetDBParameter("@SORTDIRECTION", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.sortDirection));
            ParameterList.Add(DataAccess.GetDBParameter("@PAGENUMBER", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, model.pageNumber));
            ParameterList.Add(DataAccess.GetDBParameter("@PAGESIZE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, model.pageSize));
            ParameterList.Add(DataAccess.GetDBParameter("@RESULTCOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Output, model.resultCount));
            ParameterList.Add(DataAccess.GetDBParameter("@TOTALPAGECOUNT", SqlDbType.Int, DbConstant.INT, ParameterDirection.Output, model.resultCount));

            dt = DataAccess.ExecSPReturnDataTable("PREMPLOYEESEARCH", ParameterList);
            //foreach (SqlParameter sp in ParameterList)
            //{
            //    if (sp.Direction == ParameterDirection.Output)
            //    {
            //        if (sp.ParameterName == "@RESULTCOUNT")
            //            model.resultCount = (int)sp.Value;

            //        if (sp.ParameterName == "@TOTALPAGECOUNT")
            //            model.resultCount = (int)sp.Value;
            //    }
            //}
            return EmployeeSearchModel.TranslateAsSearchList(dt);

        }

        public static int AddEmployeeData(EmployeeAddModel model)
        {
            List<SqlParameter> ParameterList = new List<SqlParameter>();

            ParameterList.Add(DataAccess.GetDBParameter("@NAME", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.name));
            ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.gender));
            ParameterList.Add(DataAccess.GetDBParameter("@SALARY", SqlDbType.Decimal, DbConstant.DECIMAL, ParameterDirection.Input, model.salary));
            ParameterList.Add(DataAccess.GetDBParameter("@DATEOFJOIN", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.dateOfJoin));

            int n = DataAccess.ExecSPReturnInt("PREMPLOYEEINSERT", ParameterList);

            return n;

        }


        public static int EditEmployeeData(EmployeeEditModel model)
        {
            List<SqlParameter> ParameterList = new List<SqlParameter>();
            ParameterList.Add(DataAccess.GetDBParameter("@ID", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, model.id));
            ParameterList.Add(DataAccess.GetDBParameter("@NAME", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.name));
            ParameterList.Add(DataAccess.GetDBParameter("@GENDER", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.gender));
            ParameterList.Add(DataAccess.GetDBParameter("@SALARY", SqlDbType.Decimal, DbConstant.DECIMAL, ParameterDirection.Input, model.salary));
            ParameterList.Add(DataAccess.GetDBParameter("@DATEOFJOIN", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.dateOfJoin));

            int n = DataAccess.ExecSPReturnInt("PREDITEMPLOYEEINSERT", ParameterList);

            return n;

        }


    }
}
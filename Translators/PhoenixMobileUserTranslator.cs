using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SouthNests.Phoenix.Framework;
using System.Web.Script.Serialization;
using SouthNests.PhoenixMobile.Model;

namespace SouthNests.PhoenixMobile.Translators
{
    public class PhoenixMobileUserTranslator
    {
        public static List<MobileUsersModel> ListMobileUsers(string name)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> ParameterList = new List<SqlParameter>();

           
            ParameterList.Add(DataAccess.GetDBParameter("@NAME", SqlDbType.NVarChar, DbConstant.NVARCHAR_500, ParameterDirection.Input, name));
            dt = DataAccess.ExecSPReturnDataTable("PRMOBILEUSERSLIST", ParameterList);

            return MobileUsersModelTranslator.TranslateAsUsersList(dt);

        }

        public static List<MobileModuleItem> ListModuleItems(string code)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> ParameterList = new List<SqlParameter>();


            ParameterList.Add(DataAccess.GetDBParameter("@CODE", SqlDbType.NVarChar, DbConstant.NVARCHAR_500, ParameterDirection.Input, code));
            dt = DataAccess.ExecSPReturnDataTable("PRMOBILEMODULEITEMS", ParameterList);

            return MobileModuleItemTranslator.TranslateAsModuleItemList(dt);

        }

        public static AuthenticateUser LoginMobileUser(MobileUserSignup u)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> ParameterList = new List<SqlParameter>();

            ParameterList.Add(DataAccess.GetDBParameter("@USERNAME", SqlDbType.NVarChar, DbConstant.NVARCHAR_500, ParameterDirection.Input, u.email));
            ParameterList.Add(DataAccess.GetDBParameter("@PASSWORD", SqlDbType.NVarChar, DbConstant.NVARCHAR_500, ParameterDirection.Input, u.password));

            dt = DataAccess.ExecSPReturnDataTable("PRMOBILEUSERLOGIN", ParameterList);

            return MobileUsersModelTranslator.TranslateAsAuthenticateUser(dt);
        }

        public static int InsertMobileUser(MobileUsersModel m)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> ParameterList = new List<SqlParameter>();

            ParameterList.Add(DataAccess.GetDBParameter("@ROWUSERCODE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, 1));
            ParameterList.Add(DataAccess.GetDBParameter("@NAME", SqlDbType.NVarChar, DbConstant.NVARCHAR_500, ParameterDirection.Input, m.Name));
            ParameterList.Add(DataAccess.GetDBParameter("@EMAIL", SqlDbType.NVarChar, DbConstant.NVARCHAR_500, ParameterDirection.Input, m.EmailId));
            ParameterList.Add(DataAccess.GetDBParameter("@ADDRESS", SqlDbType.NVarChar, DbConstant.NVARCHAR_MAX, ParameterDirection.Input, m.Address));
            ParameterList.Add(DataAccess.GetDBParameter("@MOBILE", SqlDbType.NVarChar, DbConstant.NVARCHAR_20, ParameterDirection.Input, m.Mobile));
            ParameterList.Add(DataAccess.GetDBParameter("@ISACTIVE", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, m.IsActive));
            ParameterList.Add(DataAccess.GetDBParameter("@ISAPPROVED", SqlDbType.Int, DbConstant.INT, ParameterDirection.Input, m.IsApproved));
            ParameterList.Add(DataAccess.GetDBParameter("@PUSHTOKEN", SqlDbType.NVarChar, DbConstant.NVARCHAR_200, ParameterDirection.Input, m.PushToken));
            ParameterList.Add(DataAccess.GetDBParameter("@DOJ", SqlDbType.DateTime, DbConstant.DATETIME, ParameterDirection.Input, m.Doj));
            int n = DataAccess.ExecSPReturnInt("PRMOBILEUSERINSERT", ParameterList);

            return n;

        }

        public static AuthenticateUser SignupMobileUser(MobileUserSignup u)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> ParameterList = new List<SqlParameter>();

            ParameterList.Add(DataAccess.GetDBParameter("@USERNAME", SqlDbType.NVarChar, DbConstant.NVARCHAR_500, ParameterDirection.Input, u.email));
            ParameterList.Add(DataAccess.GetDBParameter("@PASSWORD", SqlDbType.NVarChar, DbConstant.NVARCHAR_500, ParameterDirection.Input, u.password));

            dt = DataAccess.ExecSPReturnDataTable("PRMOBILEUSERSIGNUP", ParameterList);

            return MobileUsersModelTranslator.TranslateAsAuthenticateUser(dt);
        }

    }
}
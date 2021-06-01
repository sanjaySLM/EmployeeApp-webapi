using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SouthNests.Phoenix.Framework;
using System.Web.Script.Serialization;
using SouthNests.PhoenixMobile.Model;

namespace SouthNests.PhoenixMobile.Translators
{
    public class PhoenixMobilePlacesTranslator
    {
        public static List<PlacesListModel> ListPlaces(string name)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> ParameterList = new List<SqlParameter>();

            dt = DataAccess.ExecSPReturnDataTable("PRPLACESLIST", ParameterList);

            return PlacesListModel.TranslateAsPLacesList(dt);

        }

        public static int AddPlaceData(PlaceAddModel model)
        {
            List<SqlParameter> ParameterList = new List<SqlParameter>();

            ParameterList.Add(DataAccess.GetDBParameter("@NAME", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.name));
            ParameterList.Add(DataAccess.GetDBParameter("@IMAGEURL", SqlDbType.VarChar, DbConstant.VARCHAR_200, ParameterDirection.Input, model.imageurl));


            int n = DataAccess.ExecSPReturnInt("PRPLACESINSERT", ParameterList);

            return n;

        }
    }
}
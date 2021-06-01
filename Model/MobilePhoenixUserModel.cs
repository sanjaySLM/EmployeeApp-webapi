using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data;
using SouthNests.Phoenix.Framework;

namespace SouthNests.PhoenixMobile.Model
{

    public class MobilePhoenixUserLogin
    {
        [DataMember(Name = "username")]
        public string username { get; set; }

        [DataMember(Name = "password")]
        public string password { get; set; }
    }

    [DataContract]
    public class MobilePhoenixUserContext
    {
        [DataMember(Name = "username")]
        public string username { get; set; }

        [DataMember(Name = "rowusercode")]
        public int?  rowusercode { get; set; }


        public static MobilePhoenixUserContext TranslateAsUserContext(DataRow dr)
        {
            var item = new MobilePhoenixUserContext();

            item.rowusercode = General.GetNullableInteger(dr["FLDUSERCODE"].ToString());
            item.username = General.GetNullableString(dr["FLDUSERNAME"].ToString());          
            return item;
        }
        public static List<MobilePhoenixUserContext> TranslateAsUserContextList(DataTable dt)
        {
            var list = new List<MobilePhoenixUserContext>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(TranslateAsUserContext(dr));
            }
            return list;
        }
    }

}
    
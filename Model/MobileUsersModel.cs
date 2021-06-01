using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data;
using SouthNests.Phoenix.Framework;

namespace SouthNests.PhoenixMobile.Model
{
    [DataContract]
    public class MobileModuleItem
    {
        [DataMember(Name = "code")]
        public string code { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "status")]
        public string status { get; set; }

        [DataMember(Name = "dtkey")]
        public string dtkey { get; set; }

    }


    [DataContract]
    public class MobileUserSignup
    {
        [DataMember(Name ="email")]
        public string email { get; set; }

        [DataMember(Name="password")]
        public string password { get; set; }
    }

    [DataContract]
    public class AuthenticateUser
    {
        [DataMember(Name ="localId")]
        public string localId { get; set; }

        [DataMember(Name ="idToken")]

        public string idToken { get; set; }
    }

    

    [DataContract]
    public class AuthenticateErrorMessage
    {
        [DataMember(Name ="message")]
        public string message { get; set; }

        [DataMember(Name ="code")]
        public string code { get; set; }
    }

    [DataContract]
    public class AuthenticateError
    {
        [DataMember(Name ="error")]
        public AuthenticateErrorMessage aem { get; set; }
    }

   


    [DataContract]
    public class MobileUsersModel
    {
        [DataMember(Name ="Id")]
        public int? Id { get; set; }

        [DataMember(Name ="Name")]
        public string Name { get; set; }

        [DataMember(Name ="EmailId")]
        public string EmailId { get; set; }

        [DataMember(Name ="Mobile")]
        public string Mobile { get; set; }

        [DataMember(Name ="Address")]
        public string Address { get; set; }

        [DataMember(Name ="IsActive")]
        public int? IsActive { get; set; }

        [DataMember(Name ="IsApproved")]
        public int? IsApproved { get; set; }

        [DataMember(Name = "PushToken")]
        public string PushToken { get; set; }

        [DataMember(Name = "Doj")]
        public DateTime? Doj { get; set; }

    }


    public class MobileModuleItemTranslator
    {
        public static MobileModuleItem TranslateAsModelItem(DataRow dr)
        {
            var item = new MobileModuleItem();

            item.code = General.GetNullableString(dr["FLDCODE"].ToString());
            item.name = General.GetNullableString(dr["FLDNAME"].ToString());
            item.type = General.GetNullableString(dr["FLDTYPE"].ToString());
            item.status = General.GetNullableString(dr["FLDSTATUS"].ToString());
            item.dtkey = General.GetNullableString(dr["FLDDTKEY"].ToString());
            return item;
        }

        public static List<MobileModuleItem> TranslateAsModuleItemList(DataTable dt)
        {
            var list = new List<MobileModuleItem>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(TranslateAsModelItem(dr));
            }
            return list;
        }
    }



    public class MobileUsersModelTranslator
    {
        public static MobileUsersModel TranslateAsUser(DataRow dr)
        {
            var item = new MobileUsersModel();

            item.Id = General.GetNullableInteger(dr["FLDID"].ToString());
            item.Name = General.GetNullableString(dr["FLDNAME"].ToString());
            item.EmailId = General.GetNullableString(dr["FLDEMAIL"].ToString());
            item.Address = General.GetNullableString(dr["FLDADDRESS"].ToString());
            item.Mobile = General.GetNullableString(dr["FLDMOBILE"].ToString());
            item.IsActive = General.GetNullableInteger(dr["FLDISACTIVE"].ToString());
            item.IsApproved = General.GetNullableInteger(dr["FLDISAPPROVED"].ToString());
            item.Mobile = General.GetNullableString(dr["FLDPUSHTOKEN"].ToString());
            item.Doj = General.GetNullableDateTime(dr["FLDDOJ"].ToString());

            return item;
        }

        public static List<MobileUsersModel> TranslateAsUsersList(DataTable dt)
        {
            var list = new List<MobileUsersModel>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(TranslateAsUser(dr));
            }
            return list;
        }


        public static AuthenticateUser TranslateAsAuthenticateUser(DataTable dt)
        {
            var item = new AuthenticateUser();

            DataRow dr = dt.Rows[0];

            item.localId = General.GetNullableString(dr["FLDUSERID"].ToString());
            item.idToken = General.GetNullableString(dr["FLDDTKEY"].ToString());

            return item;
        }
    }
}
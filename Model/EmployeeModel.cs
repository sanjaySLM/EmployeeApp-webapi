using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data;
using SouthNests.Phoenix.Framework;
using SouthNests.PhoenixMobile.Translators;

namespace SouthNests.PhoenixMobile.Model
{
    [DataContract]
    public class EmployeeId
    {
        [DataMember(Name = "employeeId")]
        public string employeeId { get; set; }
    }

    

    [DataContract]
    public class EmployeeSearch
    {
        [DataMember(Name = "employeeName")]
        public string employeeName { get; set; }
        [DataMember(Name = "sortBy")]
        public string sortBy { get; set; }
        [DataMember(Name = "sortDirection")]
        public string sortDirection { get; set; }
        [DataMember(Name = "pageNumber")]
        public int pageNumber { get; set; }
        [DataMember(Name = "pageSize")]
        public int pageSize { get; set; }
        [DataMember(Name = "resultCount")]
        public int? resultCount { get; set; }
        [DataMember(Name = "totalPageCount")]
        public int? totalPageCount { get; set; }

    }


    [DataContract]
    public class EmployeeSearchModel
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "gender")]
        public string gender { get; set; }
        [DataMember(Name = "salary")]
        public string salary { get; set; }
        [DataMember(Name = "dateOfJoin")]
        public string dateOfJoin { get; set; }

        public static EmployeeSearchModel TranslateAsSearchEmployee(DataRow dr)
        {
            var item = new EmployeeSearchModel();

            item.id = General.GetNullableString(dr["FLDEMPLOYEEID"].ToString());
            item.name = General.GetNullableString(dr["FLDEMPLOYEENAME"].ToString());
            item.gender = General.GetNullableString(dr["FLDGENDER"].ToString());
            item.salary = General.GetNullableString(dr["FLDSALARY"].ToString());
            item.dateOfJoin = General.GetNullableString(dr["FLDDATEOFJOIN"].ToString());

            return item;
        }
        public static List<EmployeeSearchModel> TranslateAsSearchList(DataTable dt)
        {
            var list = new List<EmployeeSearchModel>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(TranslateAsSearchEmployee(dr));
            }
            return list;
        }
    }




    [DataContract]
    public class EmployeeListModel
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "gender")]
        public string gender { get; set; }
        [DataMember(Name = "salary")]
        public string salary { get; set; }
        [DataMember(Name = "dateOfJoin")]
        public string dateOfJoin { get; set; }

        public static EmployeeListModel TranslateAsEmployee(DataRow dr)
        {
            var item = new EmployeeListModel();

            item.id = General.GetNullableString(dr["FLDEMPLOYEEID"].ToString());
            item.name = General.GetNullableString(dr["FLDEMPLOYEENAME"].ToString());
            item.gender = General.GetNullableString(dr["FLDGENDER"].ToString());
            item.salary = General.GetNullableString(dr["FLDSALARY"].ToString());
            item.dateOfJoin = General.GetNullableString(dr["FLDDATEOFJOIN"].ToString());

            return item;
        }
        public static List<EmployeeListModel> TranslateAsEmployeeList(DataTable dt)
        {
            var list = new List<EmployeeListModel>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(TranslateAsEmployee(dr));
            }
            return list;
        }
    }



    [DataContract]
    public class EmployeeAddModel
    {
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "gender")]
        public string gender { get; set; }
        [DataMember(Name = "salary")]
        public string salary { get; set; }
        [DataMember(Name = "dateOfJoin")]
        public string dateOfJoin { get; set; }

        public static EmployeeAddModel TranslateAsAddEmployee(DataRow dr)
        {
            var item = new EmployeeAddModel();

            item.name = General.GetNullableString(dr["FLDEMPLOYEENAME"].ToString());
            item.gender = General.GetNullableString(dr["FLDGENDER"].ToString());
            item.salary = General.GetNullableString(dr["FLDSALARY"].ToString());
            item.dateOfJoin = General.GetNullableString(dr["FLDDATEOFJOIN"].ToString());

            return item;
        }

    }


    [DataContract]
    public class EmployeeEditModel
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "gender")]
        public string gender { get; set; }
        [DataMember(Name = "salary")]
        public string salary { get; set; }
        [DataMember(Name = "dateOfJoin")]
        public string dateOfJoin { get; set; }

        public static EmployeeEditModel TranslateAsEditEmployee(DataRow dr)
        {
            var item = new EmployeeEditModel();
            item.id = General.GetNullableString(dr["FLDEMPLOYEEID"].ToString());
            item.name = General.GetNullableString(dr["FLDEMPLOYEENAME"].ToString());
            item.gender = General.GetNullableString(dr["FLDGENDER"].ToString());
            item.salary = General.GetNullableString(dr["FLDSALARY"].ToString());
            item.dateOfJoin = General.GetNullableString(dr["FLDDATEOFJOIN"].ToString());

            return item;
        }

    }
    
}

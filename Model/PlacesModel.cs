using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data;
using SouthNests.Phoenix.Framework;
using SouthNests.PhoenixMobile.Translators;



namespace SouthNests.PhoenixMobile.Model
{
    [DataContract]
    public class PlacesId
    {
        [DataMember(Name = "placesId")]
        public string placesId { get; set; }
    }

    [DataContract]
    public class PlacesListModel
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "imageurl")]
        public string imageurl { get; set; }

        public static PlacesListModel TranslateAsPlaces(DataRow dr)
        {
            var item = new PlacesListModel();

            item.id = General.GetNullableString(dr["FLDPLACESID"].ToString());
            item.name = General.GetNullableString(dr["FLDPLACESNAME"].ToString());
            item.imageurl = General.GetNullableString(dr["FLDIMAGEURL"].ToString());


            return item;
        }
        public static List<PlacesListModel> TranslateAsPLacesList(DataTable dt)
        {
            var list = new List<PlacesListModel>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(TranslateAsPlaces(dr));
            }
            return list;
        }
    }


    [DataContract]
    public class PlaceAddModel
    {
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "imageurl")]
        public string imageurl { get; set; }


        public static PlaceAddModel TranslateAsAddPlace(DataRow dr)
        {
            var item = new PlaceAddModel();

            item.name = General.GetNullableString(dr["FLDPLACESNAME"].ToString());
            item.imageurl = General.GetNullableString(dr["FLDIMAGEURL"].ToString());


            return item;
        }

    }
}
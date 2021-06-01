using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;



namespace SouthNests.Phoenix.Framework
{
    /// <summary>
    /// Summary description for general
    /// </summary>
    public class General
    {
        public General()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Checks whether the string value can be evaluated to a value of type (int?).
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>int? Nullable int value</returns>
        public static int? GetNullableInteger(string value)
        {
            int? i = null;
            int ii;

            if (int.TryParse(value, out ii))
                i = ii;
            return i;
        }


        public static Guid? GetNullableGuid(string value)
        {
            try
            {
                Guid result = new Guid(value);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string GetNullableString(string value)
        {
            if (string.IsNullOrEmpty(value) || value.ToUpper().Equals("DUMMY") || value.Trim().Equals(""))
                return null;
            return value;
        }
        /// <summary>
        /// Gets a nullable date time value for a datetime string provided it is either null string or invalid date string
        /// </summary>
        /// <param name="datetime">datetime value represented as string</param>
        /// <returns>DateTime?: Nullable datetime object is returned if 1st argument is either null string or invalid date string</returns>
        public static DateTime? GetNullableDateTime(string datetime)
        {
            DateTime? dt = null;
            DateTime dtt;

            if (DateTime.TryParse(datetime, out dtt))
                dt = dtt;
            return dt;
        }

        /// <summary>
        /// Gets a nullable Decimal for the string provided it is either null string or invalid decimal string
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Decimal?: Nullable decimal object</returns>
        public static Decimal? GetNullableDecimal(string value)
        {
            decimal? result = null;
            decimal tmpvalue;

            if (decimal.TryParse((string)value, out tmpvalue))
                result = tmpvalue;
            return result;
        }
        /// <summary>
        /// Gets a string for the date time string provided it is either null string or invalid format string
        /// </summary>
        /// <param name="datetimestring"> datase datetime values </param>
        /// <returns> Short Date String based on the configuration</returns>
        public static string GetDateTimeToString(string datetimestring)
        {
            string dtformatstring = null;
            DateTime dtt;

            if (DateTime.TryParse(datetimestring, out dtt))
                dtformatstring = dtt.ToString("d");
            return dtformatstring;
        }
        /// <summary>
        /// Gets a date time object
        /// </summary>
        /// <param name="d">Date Time Object</param>
        /// <returns>Configured Shrot Date string</returns>
        public static string GetDateTimeToString(object datetime)
        {
            string datetimestring = string.Empty;
            if (datetime is DateTime)
                datetimestring = ((DateTime)datetime).ToString("d");
            return datetimestring;
        }

    }
}
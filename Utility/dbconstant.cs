using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SouthNests.Phoenix.Framework
{
	public class DbConstant
	{
		public DbConstant()
		{
		}

		/// <summary>
		/// Tinyint ,Smallint ,Int, Bigint, Decimal, Datetime and Uniqueidentifier constant values.
		/// </summary>

		public const int TINYINT = 1;
		public const int SMALLINT = 2;
		public const int INT = 4;
		public const int BIGINT = 8;
		public const int DECIMAL = 9;
		public const int UNIQUEIDENTIFIER = 16;
		public const int DATETIME = 10;

		/// <summary>
		///  NVARCHAR constant values
		/// </summary>
		/// 

        public const int NVARCHAR_5 = 5;
        public const int NVARCHAR_10 = 10;
        public const int NVARCHAR_20 = 20;
		public const int NVARCHAR_50 = 50;
		public const int NVARCHAR_100 = 100;
		public const int NVARCHAR_200 = 200;
		public const int NVARCHAR_400 = 400;
		public const int NVARCHAR_500 = 500;
		public const int NVARCHAR_MAX = -1;

		/// <summary>
		///  VARCHAR constant values
		/// </summary>
		/// 
        public const int VARCHAR_5 = 5;
        public const int VARCHAR_10 = 10;
        public const int VARCHAR_20 = 20;
        public const int VARCHAR_50 = 50;
		public const int VARCHAR_100 = 100;
		public const int VARCHAR_200 = 200;
		public const int VARCHAR_400 = 400;
		public const int VARCHAR_500 = 500;
		public const int VARCHAR_MAX = -1;

	}
}
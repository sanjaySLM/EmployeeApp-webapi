using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;

namespace SouthNests.Phoenix.Framework
{
    public class SPCollectionItem
    {
        public string ProcedureName;
        public List<SqlParameter> Parameters;
    }
}



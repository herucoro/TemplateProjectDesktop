using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RyoeiSystem.Database.Common
{
    public static class DatabaseCommon
    {
        public static void AddSqlParameter(SqlCommand com, string parameterName, SqlDbType type, Object value)
        {
            SqlParameter param = com.CreateParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = type;
            param.Value = value;
            com.Parameters.Add(param);
        }
    }
}

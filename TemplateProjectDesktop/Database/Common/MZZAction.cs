using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using RyoeiSystem.Database.Common;
using RyoeiSystem.SecretData;

namespace RyoeiSystem.Database.Common
{
    public class MZZAction
    {
        public static readonly int userId;
        public static readonly string assemblyName;

        static MZZAction()
        {
            string sql;

            // アセンブリ名を設定
            assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            // 社員CDを設定
            using (var connection = new SqlConnection(Secret.connectionString))
            {
                connection.Open();

                sql = @"SELECT MZZTANTO 
                        FROM MZZ 
                        WHERE MZZWSID = @machineName 
                        AND MZZPROID LIKE @assemblyName 
                        ;";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Clear();
                    DatabaseCommon.AddSqlParameter(command, "@machineName", System.Data.SqlDbType.NChar, Environment.MachineName);
                    DatabaseCommon.AddSqlParameter(command, "@assemblyName", System.Data.SqlDbType.NChar, assemblyName + "%");

                    using (var dataReader = command.ExecuteReader())
                    {
                        dataReader.Read();

                        if (!dataReader.HasRows)
                        {
                            userId = 0;
                        }
                        else
                        {
                            userId = (int)dataReader["MZZTANTO"];
                        }
                    }
                }

                connection.Close();
            }            
        }

        public void Close()
        {
            string sql;

            using (var connection = new SqlConnection(Secret.connectionString))
            {
                connection.Open();

                sql = @"DELETE 
                        FROM MZZ 
                        WHERE MZZTANTO = @userId 
                        AND MZZPROID LIKE @assemblyName 
                        ;";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Clear();
                    DatabaseCommon.AddSqlParameter(command, "@userId", System.Data.SqlDbType.Int, userId);
                    DatabaseCommon.AddSqlParameter(command, "@assemblyName", System.Data.SqlDbType.NChar, assemblyName + "%");

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

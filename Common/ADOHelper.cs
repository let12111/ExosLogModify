using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ADOHelper
    {
        public static bool CheckConnection(string connstring)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connstring))
                {

                    con.Open();
                    return con.State == System.Data.ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<T> MapAll<T>(SqlDataReader sqlReader) where T : new()
        {
            List<T> newList = new List<T>();

            while (sqlReader.Read()) newList.Add(Map<T>(sqlReader));

            return newList;
        }


        public static T Map<T>(SqlDataReader sqlReader) where T : new()
        {
            T mapObject = new T();

            Dictionary<string, PropertyInfo> pInfo = mapObject.GetType()
                .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);


            for (int i = 0; i < sqlReader.FieldCount; i++)
            {
                var name = sqlReader.GetName(i);
                if (!pInfo.ContainsKey(name)) continue;
                var mapProp = pInfo[name];

                Type t = Nullable.GetUnderlyingType(mapProp.PropertyType) ?? mapProp.PropertyType;

                object safeValue = (sqlReader[i] == null || sqlReader[i] == DBNull.Value) ? null : Convert.ChangeType(sqlReader[i], t);

                mapProp.SetValue(mapObject, safeValue, null);

            }
            return mapObject;
        }
    }
}

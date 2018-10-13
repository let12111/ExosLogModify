using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Contracts;
using Contracts.SDO;
using Contracts.Interface;
namespace Commutator
{
    class ExosCommutator : ICommutator
    {
        string connectionString { get; set; }
        ILogger logger;
        public ExosCommutator()
        {
        }

        public void DeleteAClog(ACLog lACLog)
        {
            throw new NotImplementedException();
        }

        public List<ACLog> GetACLogs(DateTime dateBeg, DateTime dateEnd, int persID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.Parameters.AddWithValue("@DATE_BEG", dateBeg);
                    com.Parameters.AddWithValue("@DATE_END", dateEnd);
                    com.Parameters.AddWithValue("@PERS_ID", persID);
                    com.CommandText = "SELECT * FROM LACLOG WHERE LOGDATE BETWEEN @DATE_BEG AND @DATE_END AND PERSID=@PERS_ID";
                    var sqlDataReader = com.ExecuteReader();
                    return ADOHelper.MapAll<ACLog>(sqlDataReader);
                }
            }
            catch (Exception ex)
            {
                logger.Log("GetACLogs", ex);
                return new List<ACLog>();
            }
        }

        public List<Event> GetEvents()
        {
            throw new NotImplementedException();
        }

        public byte[] GetPersonImage()
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPersons()
        {
            throw new NotImplementedException();
        }

        public List<Point> GetPoints()
        {
            throw new NotImplementedException();
        }

        public void InsertAclog(ACLog lACLog)
        {
            throw new NotImplementedException();
        }

        public void UpdateACLog(ACLog lACLog)
        {
            throw new NotImplementedException();
        }
    }
}

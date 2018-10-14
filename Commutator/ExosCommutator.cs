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
                    com.CommandText = @"SELECT LOGID LogId, LOGDATE logDate, NAME PersonName, 
                      CardNr CardNr,
                      cft.FixText EventName,
                        lACLog.RecordType eventID
                          FROM LACLOG 
  join cFixText cft on cft.ApplID=lACLog.LogType and cft.LanguageFK='RUS' and cft.TextID=lACLog.RecordType
WHERE LOGDATE BETWEEN @DATE_BEG AND @DATE_END AND PERSID=@PERS_ID";
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

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {



                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandText = @"select TextID, Fixtext from cFixText where ApplID=6 and LanguageFK='RUS' ";
                    var sqlDataReader = com.ExecuteReader();
                    return ADOHelper.MapAll<Event>(sqlDataReader);
                }
            }
            catch (Exception ex)
            {
                logger.Log("GetEvents", ex);
                return new List<Event>();
            }


        }


        
        public byte[] GetPersonImage(int PersID )
        {
            using (SqlConnection SQLCon = new SqlConnection(connectionString))
            {

                try
                {
                    List<SqlParameter> prms = new List<SqlParameter>();
                    SqlCommand SQLC = null;
                    
                        SQLC = new SqlCommand("select Picture from hperson where PersID=@PersID", SQLCon);

                        SqlParameter sqlParameter = new SqlParameter("PersID", System.Data.SqlDbType.Int);
                        sqlParameter.Value = PersID;
                        prms.Add(sqlParameter);
 

                    SQLCon.Open();
                   var ret=  SQLC.ExecuteScalar();


                    if (ret == DBNull.Value)
                    {
                        return null;
                    }
                    else
                    {
                        return (byte[])ret;
                    }
                  



                }
                catch (Exception ex)
                {
                    logger.Log("",ex);
                }
                return null;

            }




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
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {

                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    com.CommandText = "insert into LACLOG";

                }
                catch (Exception ex)
                {
                    logger.Log("", ex);
                }
            }
        }
        public void UpdateACLogDate(int logID, DateTime Logdate)
        {
            throw new NotImplementedException();
        }


        public void DeleteAClog(int logID) { }
    }
}

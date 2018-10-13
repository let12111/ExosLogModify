using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.SDO;
namespace Contracts
{
  public  interface ICommutator
    {
        List<Event> GetEvents();
        List<Point> GetPoints();
        List<Person> GetPersons();
        byte[] GetPersonImage();
        List<ACLog> GetACLogs(DateTime dateBeg, DateTime dateEnd, int persID);
        void UpdateACLog(ACLog lACLog);
        void InsertAclog(ACLog lACLog);
        void DeleteAClog(ACLog lACLog);
    }
}

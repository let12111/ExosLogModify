using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Contracts.SDO;

namespace Commutator
{
    class ExosCommutator : ICommutator
    {
        public void DeleteAClog(ACLog lACLog)
        {
            throw new NotImplementedException();
        }

        public List<ACLog> GetACLogs(DateTime dateBeg, DateTime dateEnd, int persID)
        {
            throw new NotImplementedException();
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

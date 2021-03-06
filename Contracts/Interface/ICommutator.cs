﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.SDO;
namespace Contracts.Interface
{
  public  interface ICommutator
    {
        List<Event> GetEvents();
        List<Point> GetPoints();
        List<Person> GetPersons();
        byte[] GetPersonImage(int PersID);
        List<ACLog> GetACLogs(DateTime dateBeg, DateTime dateEnd, int persID);
        void UpdateACLogDate(int logID, DateTime Logdate);
        void InsertAclog(ACLog lACLog);
        void DeleteAClog( int logID);
    }
}

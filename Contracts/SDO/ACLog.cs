using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SDO
{
    public class ACLog
    {
        int LogId { get; set; }
        int PersID { get; set; }
        string PersonName { get; set; }
        string EventName { get; set; }
        DateTime LogDate { get; set; }
    }
}

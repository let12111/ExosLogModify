using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SDO
{
    public class ACLog
    {
        public int LogId { get; set; }
        public int PersID { get; set; }
        public string CardNr { get; set; }
        public string PersonName { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime LogDate { get; set; }
    }
}

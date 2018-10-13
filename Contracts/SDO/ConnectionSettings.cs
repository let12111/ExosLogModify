using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.SDO
{
  public  class ConnectionSettings
    {
        string ServerName { get; set; }
        string DatabaceName { get; set; }
        string UserName { get; set; }
        string UserPassword { get; set; }
    }
}

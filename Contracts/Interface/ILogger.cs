using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface
{
  public  interface ILogger
    {
        void Log(string message);
        void Log(string message, Exception ex);

    }
}

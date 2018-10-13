using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class ConnectionDataManager
    {
        public string DBName { get; set; }
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string ConnectionString { get; set; }
    }
}

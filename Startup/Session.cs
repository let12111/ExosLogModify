using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Interface;
using Contracts.SDO;
namespace Startup
{
    class Session
    {
        public static ISettings Settings { get; set; }
        public  static  ICommutator ExosCommutator { get; set; }
        public  static  ISerialisationManager SerializationManager { get; set; }

    }
}

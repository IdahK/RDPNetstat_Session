using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDPNetstat_Session
{
    public class Port
    {
        public string protocol
        {
            get;
            set;
        }
         

        public string serveraddr
        {
            get;
            set;
        }
        public string machineaddr
        {
            get;
            set;
        }
        public string state {
            get;
            set;
        }
    }
}

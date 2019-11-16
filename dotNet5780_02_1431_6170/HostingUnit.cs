using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class HostingUnit
    {
        private static int stSerialKey = 10000000;
        public int HostingUnitKey { get; private set; }

        
        public HostingUnit()
        {
            this.HostingUnitKey = stSerialKey++;
        }
    }
}






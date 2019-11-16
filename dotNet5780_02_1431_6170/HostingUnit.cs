using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class HostingUnit
    {
        private static int stSerialKey;
        public int HostingUnitKey;

        public int Hosting
        {
            get
            {
                return HostingUnitKey;
            }
            private set
            {
                HostingUnitKey = stSerialKey;
            }
        }

        HostingUnit()
        {
            ++stSerialKey;
        }
    }
}

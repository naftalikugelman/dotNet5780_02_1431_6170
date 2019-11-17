using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class Host
    {
        public int HostKey { get; set; }
        public List<HostingUnit> HostingUnitCollection { get; set; }

        public Host(int Id, int count )
        {
            HostKey = Id;
            int Count = count;

          
            //TO DO all rooms a available

        }

        public override string ToString()
        {
            String str ="";
            foreach (HostingUnit item in HostingUnitCollection)
            {
                str += item.ToString();
            }
            return str; 
        }

        
        
        
    }
}

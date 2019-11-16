using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class Program
    {
        static void Main(string[] args)
        {
            HostingUnit id1 = new HostingUnit();
            HostingUnit id2 = new HostingUnit();
            Console.WriteLine("id: {0}", id1.HostingUnitKey);
            Console.WriteLine("id: {0}", id2.HostingUnitKey);
            Console.ReadKey();
        }
    }
}

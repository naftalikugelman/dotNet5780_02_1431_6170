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
            GuestRequest g1 = new GuestRequest(1, 01, 02, 08);

            Console.WriteLine(g1.numOfDays());

            HostingUnit id1 = new HostingUnit();
            HostingUnit id2 = new HostingUnit();
            id1.ApproveRequest(g1);
            id1.debbugingPrintCalendar();
            Console.WriteLine(id1);



            Host h1 = new Host(1234567, 14);
            h1.ToString();




        }
    }
}

//Daniel vofchuk and naftali kugelmann

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        private static GuestRequest CreateRandomRequest()
        {
            int startMonth = rand.Next(1, 13);
            int startDay = rand.Next(1, 32);
            int numOfDays = rand.Next(1, 11);

            Date date = new Date(startDay, startMonth);//takes the inicial dates

            for (int i = 0; i < numOfDays; i++)//addes the random num of days in a range of max 10 das
            {
                date.nextDay();
            }

            GuestRequest gs = new GuestRequest(startDay, startMonth, date.Day, date.Month);
            return gs;
        }//givven code
        static void Main(string[] args)
        {
            List<Host> lsHosts;
            lsHosts = new List<Host>()
    {
    new Host(1, rand.Next(1,5)),
    new Host(2, rand.Next(1,5)),
    new Host(3, rand.Next(1,5)),
    new Host(4, rand.Next(1,5)),
    new Host(5, rand.Next(1,5))
    };
            for (int i = 0; i < 100; i++)
            {
                foreach (var host in lsHosts)
                {

                    GuestRequest gs1 = CreateRandomRequest();
                    GuestRequest gs2 = CreateRandomRequest();
                    GuestRequest gs3 = CreateRandomRequest();
                    switch (rand.Next(1, 4))
                    {
                        case 1:
                            host.AssignRequests(gs1);
                            break;
                        case 2:
                            host.AssignRequests(gs1, gs2);
                            break;
                        case 3:
                            host.AssignRequests(gs1, gs2, gs3);
                            break;
                        default:
                            break;
                    }
                }
            }
            //Create dictionary for all units <unitkey, occupancy_percentage>
            Dictionary<long, float> dict = new Dictionary<long, float>();
            foreach (var host in lsHosts)
            {
                //test Host IEnuramble is ok
                foreach (HostingUnit unit in host)
                {
                    dict[unit.HostingUnitKey] = unit.GetAnnualBusyPrecentege();
                }
            }
            //get max value in dictionary
            float maxVal = dict.Values.Max();
            //get max value key name in dictionary
            long maxKey =
           dict.FirstOrDefault(x => x.Value == dict.Values.Max()).Key;
            //find the Host that its unit has the maximum occupancy percentage
            foreach (var host in lsHosts)
            {
                //test indexer of Host
                for (int i = 0; i < host.HostingUnitCollection.Count; i++)
                {
                    if (host[i].HostingUnitKey == maxKey)
                    {
                        //sort this host by occupancy of its units
                        host.SortUnits();
                        //print this host detailes
                        Console.WriteLine("**** Details of the Host with the most occupied unit:\n");

                        Console.WriteLine(host);
                        break;
                    }
                }
            }
        }
    }
}


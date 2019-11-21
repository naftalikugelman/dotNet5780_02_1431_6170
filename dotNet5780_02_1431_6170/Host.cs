using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class Host : IEnumerable
    {
        public int HostKey { get; set; }
        public List<HostingUnit> HostingUnitCollection { get; set; } = new List<HostingUnit>();

        public Host(int Id, int count)
        {
            HostKey = Id;
            for (int i = 0; i < count; i++)
            {
                //HostingUnit temp = new HostingUnit();
                HostingUnitCollection.Add(new HostingUnit());
            }
        }

        public override string ToString()
        {
            String str = "";
            for (int i = 0; i < HostingUnitCollection.Count; i++)
            {
                str += HostingUnitCollection[i].ToString() + "\n";
                //str += HostingUnitCollection[i].GetAnnualBusyDays() + "\n";
            }
            //str += GetHostAnnualBusyDays();
            return str;
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
            for (int i = 0; i < HostingUnitCollection.Count; ++i)
            {
                if (HostingUnitCollection[i].ApproveRequest(guestReq))
                {
                    return HostingUnitCollection[i].HostingUnitKey;
                }
            }
            return -1;
        }

        public int GetHostAnnualBusyDays()
        {
            int sum = 0;
            for (int i = 0; i < HostingUnitCollection.Count; ++i)
            {
                sum += HostingUnitCollection[i].GetAnnualBusyDays();
            }
            return sum;
        }

        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }

        public bool AssignRequests(params GuestRequest[] guests)
        {
            bool AllRequestConfirm = true;
            for (int i = 0; i < guests.Length; ++i)
            {
                if (SubmitRequest(guests[i]) == -1) AllRequestConfirm = false;

            }
            return AllRequestConfirm;
        }

        public IEnumerator GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }

        public HostingUnit this[int index]
        {
            get { return HostingUnitCollection[index]; }
            //set { HostingUnitCollection[index] = value; }
        }
    }
}



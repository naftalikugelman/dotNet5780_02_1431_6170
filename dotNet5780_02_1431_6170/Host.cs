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
            for (int i = 0; i < HostingUnitCollection.Count; i++)
            {
                str += HostingUnitCollection[i].ToString();
                //HostingUnit unit = HostingUnitCollection[i];
                //str += HostingUnitCollection[i].HostingUnitKey.ToString();
            }
            return str;
        }


        private long SubmitRequest(GuestRequest guestReq)
        {
            for (int i = 0; i < HostingUnitCollection.Count; i++)
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
            for (int i = 0; i < HostingUnitCollection.Count; i++)
            {
                sum += HostingUnitCollection[i].GetAnnualBusyDays();
            }
            return sum;
        }

        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }        public bool AssignRequests(params GuestRequest[] guests)
        {
            bool AllRequestConfirm = true;
            for (int i = 0; i < guests.Length; i++)
            {
                if (SubmitRequest(guests[i]) == -1)
                {
                    AllRequestConfirm = false;
                }
            }
            return AllRequestConfirm;
        }

        private HostingUnit this[int index]
        {
            get { return HostingUnitCollection[index]; }
            set { HostingUnitCollection[index] = value; }
        }
        

    }
}

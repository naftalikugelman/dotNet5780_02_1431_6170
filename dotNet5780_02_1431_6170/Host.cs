using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class Host : IEnumerable<HostingUnit>
    {
        public int HostKey { get; set; }
        public List<HostingUnit> HostingUnitCollection { get; set; }

        public Host(int Id, int count)
        {
            HostKey = Id;
            for (int i = 0; i < count; i++)
            {
                HostingUnitCollection.Add(new HostingUnit());
            }
        }

        public override string ToString()
        {
            String str = "";
            for (int i = 0; i < HostingUnitCollection.Count; i++)
            {
                str += HostingUnitCollection[i].ToString() + "\n";
            }
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
            return this.GetEnumerator();
        }

         IEnumerator<HostingUnit> IEnumerable<HostingUnit>.GetEnumerator()
        {
            return new MyHostEnumerator(this);
        }

        public HostingUnit this[int index]
        {
            get { return HostingUnitCollection[index]; }
            //set { HostingUnitCollection[index] = value; }
        }

        public class MyHostEnumerator : IEnumerator<HostingUnit>
        {
            Host coll;
            HostingUnit curr;
            int cntr = -1;

            internal MyHostEnumerator(Host coll) { this.coll = coll; }

            void IDisposable.Dispose() { }

            public HostingUnit Current { get { return curr; } }

            object IEnumerator.Current { get { return this.curr; } }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (++cntr >= coll.HostingUnitCollection.Count) return false;
                else { curr = coll.HostingUnitCollection[cntr]; return true; }
            }

            public void Reset()
            {
            }
        }

    }

    
}



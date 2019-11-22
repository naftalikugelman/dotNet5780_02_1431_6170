using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class Host : IEnumerable//Ienumerator fo use of foreach
    {
        public int HostKey { get; set; }
        public List<HostingUnit> HostingUnitCollection { get; set; } = new List<HostingUnit>();//list of units

        public Host(int Id, int count)//constroctor 
        {
            HostKey = Id;
            for (int i = 0; i < count; i++)//adds new hosting units with contrsoctor that adds all days as false
            {
                //HostingUnit temp = new HostingUnit();
                HostingUnitCollection.Add(new HostingUnit());
            }
        }

        public override string ToString()
        {
            String str = "";
            for (int i = 0; i < HostingUnitCollection.Count; i++)//adds over ond over agai to the final string
            {
                str += HostingUnitCollection[i].ToString() + "\n";
            }
            //str += GetHostAnnualBusyDays();
            return str;
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
            for (int i = 0; i < HostingUnitCollection.Count; ++i)//pass over all units and tryes to add
            {
                if (HostingUnitCollection[i].ApproveRequest(guestReq))//if was aproved
                {
                    return HostingUnitCollection[i].HostingUnitKey;//return werw it was aproved
                }
            }
            return -1;
        }

        public int GetHostAnnualBusyDays()
        {
            int sum = 0;
            for (int i = 0; i < HostingUnitCollection.Count; ++i)//sums over and over agan
            {
                sum += HostingUnitCollection[i].GetAnnualBusyDays();
            }
            return sum;
        }

        public void SortUnits()
        {
            HostingUnitCollection.Sort();//uses the sort function
        }

        public bool AssignRequests(params GuestRequest[] guests)
        {
            bool AllRequestConfirm = true;//strats as true
            for (int i = 0; i < guests.Length; ++i)//tryes over all
            {
                if (SubmitRequest(guests[i]) == -1) AllRequestConfirm = false;//if recives -1 we know that not evry one was accepted

            }
            return AllRequestConfirm;//returns the resilt
        }

        public IEnumerator GetEnumerator()//ienumerator
        {
            return HostingUnitCollection.GetEnumerator();
        }

        public HostingUnit this[int index]//uses the []
        {
            get { return HostingUnitCollection[index]; }
            //set { HostingUnitCollection[index] = value; }
        }
    }
}



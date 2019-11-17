using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace dotNet5780_02_1431_6170
{
    class HostingUnit : IComparable
    {

        private static int stSerialKey = 10000000;

        public int HostingUnitKey { get;}

        private bool[][] calendar = new bool[12][];

        public int CompareTo(object obj)
        {
            return GetAnnualBusyDays().CompareTo(((HostingUnit)obj).GetAnnualBusyDays());
        }

        public void debbugingPrintCalendar()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if(calendar[i][j]) Console.Write("T ");
                    else Console.Write("F ");
                }
                Console.WriteLine();
            }
        }

        public HostingUnit()
        {
            this.HostingUnitKey = stSerialKey++;
            for (int i = 0; i < 12; i++)
            {
                calendar[i] = new bool[31];
                for (int j = 0; j < 31; j++)
                {
                    calendar[i][j] = false;
                }
            }
        }

        public override string ToString()
        {
            string finalText = "Id: " + HostingUnitKey + "\n\tLocated Dates:\n";//Will print thus string at the end
            bool flag = false;// flag to know if we are at a middle of an reservation or if we just started
            for (int i = 0; i < 12; i++)//run over the monthes
            {
                for (int j = 0; j < 31; j++)//run over the days
                {
                    if (!flag && calendar[i][j])//If this day is reservated AND the last one hasn`t
                    {
                        flag = true;//set flag to true so we van now that next TRUE day is in a middle of a reservation
                        finalText += "\tfrom " + (j + 1) + "/" + (i + 1) + " to ";//Adds the date to final print string
                    }
                    if (flag && !calendar[i][j])//If we have an FALSE day AND aur last day was a TRUE, so this reservation ends here...
                    {
                        finalText += (j + 1) + "/" + (i + 1) + "\n";//Adds the final date to the final string
                        flag = false;//sets the flagh to flase
                    }
                }
            }
            return finalText;
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            Date tempDate = new Date(guestReq.EntryDate.Day + 1, guestReq.EntryDate.Month);
            Date dateTemp = new Date(guestReq.EntryDate.Day, guestReq.EntryDate.Month);
            for (int i = 0; i < guestReq.numOfDays() ; ++i)
            {
                if(calendar[tempDate.Month - 1][tempDate.Day - 1])//Cheking if there is no other reservation at the same dates
                {
                    return false;
                }
                tempDate.nextDay();//jumps to next date
            }
            //After we know that there is no reservation we can add a new reservation
            for (int i = 0; i < guestReq.numOfDays(); i++)
            {
                calendar[dateTemp.Month - 1][dateTemp.Day - 1] = true; //to get the current date we need to add - 1
                dateTemp.nextDay();
            }
            guestReq.IsApproved = true;
            return true;//Confirm that the new reservation has been added
        }

        //runs over all year and counts how many days has reservations over the year
        public int GetAnnualBusyDays()
        {
            int sum = 0;
            for (int i = 0; i < calendar.Length; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (calendar[i][j]) sum++;
                }
            }
            return sum;
        }

        //calculates the porcentage
        public float GetAnnualBusyPercentage()
        {
            float Days = 372;
            float per;
            per = (GetAnnualBusyDays() / Days) * 100;

            return per;
        }

        
    }
}






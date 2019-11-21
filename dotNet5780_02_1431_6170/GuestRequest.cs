﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class GuestRequest
    {
        public Date EntryDate { get; set; }
        public Date ReleaseDate { get; set; }
        public bool IsApproved { get; set; }

        public GuestRequest() {
            IsApproved = false;
        }

        public GuestRequest(int entryDay, int entryMonth, int releasseDay, int releaseMonth)
        {
            EntryDate = new Date(entryDay, entryMonth);
            ReleaseDate = new Date(releasseDay, releaseMonth);
            IsApproved = false;//TODO: change this?
        }

        public int NumOfDays()
        {
            int numOfDays = 0;

            Date dayTemp = new Date(EntryDate.Day, EntryDate.Month);
            while (dayTemp.Day != ReleaseDate.Day || dayTemp.Month != ReleaseDate.Month)
            {
                ++numOfDays;
                dayTemp.nextDay();
            }
            return numOfDays;
        }

        public override string ToString()
        {
            return @"Entry Date: " + EntryDate.toString()  + "\n"  +
                    "Release Date: " + ReleaseDate.toString() + "\n" +
                    "IsApproved: " + IsApproved;
        }
    }
}

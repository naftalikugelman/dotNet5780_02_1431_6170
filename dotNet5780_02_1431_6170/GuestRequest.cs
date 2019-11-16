using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_1431_6170
{
    class GuestRequest
    {
        public DateTime EntryDate;
        public DateTime ReleaseDate;
        public bool IsApproved;

        public override string ToString()
        {
            return @"Entry Date: " + EntryDate  +  
                    "Release Date: " + ReleaseDate + 
                    "IsApproved: " + IsApproved;
        }
        
    }
}

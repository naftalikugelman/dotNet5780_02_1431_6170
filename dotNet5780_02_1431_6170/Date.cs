using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//special class to handlle dates
namespace dotNet5780_02_1431_6170
{
    class Date //Class to handle the dates
    {
        int day;
        int month;


        public int Day // getter and setter
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        //Jump to next day respecting the monthes
        public void nextDay()
        {
            if (day == 31)//need to go to nrxt month
            {
                day = 1;
                if (month == 12) month = 1;//restart the year
                else ++month;
            }
            else ++day;// just jump
        }
        //prints the current date
        public void print()
        {
            Console.WriteLine("{0}/{1}/2020", day, month);
        }

        //Return as a string
        public string toString()
        {
            return day.ToString() + "/" + month.ToString();
        }

        //Constrooctor
        public Date(int day, int month)
        {
            this.day = day;
            this.month = month;
        }
        //default constroctor
        public Date()
        {
            day = 0;
            month = 0;
        }

    }
}

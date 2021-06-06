using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backendtest
{
    static class cal_date
    {
        static private int DayOfYear(string month, string day, string year)
        {
            int d = Convert.ToInt32(day);
            int m = Convert.ToInt32(month);
            int y = Convert.ToInt32(year);

            int sum = 0;
            int[] M = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (m < 1 || m > 12)
            {
                Console.WriteLine("Month 1 to 12");
            }
            else
            {
                if (y % 4 == 0 && m >= 2)
                {
                    M[1] = 29;
                }
                if (m > 12)
                {
                    Console.WriteLine("Wrong data, Please input again");
                }
                else if (d > M[m - 1])
                {
                    Console.WriteLine("Wrong data, Please inpun again");
                }
                else
                {
                    for (int j = 0; j < m - 1; j++)
                    {
                        sum += M[j];
                    }
                    sum += d;
                    //Console.WriteLine("The day is : " + sum);
                    //Console.WriteLine(" {0} {1} {2}", d, m, y);
                }

            }
            return sum;
        }

        static public int count_start(string date_in)
        {
            //Session[start_date]
            // date_in = "2018-03-01";
            string[] date_start = date_in.Split('-');

            int y = cal_date.DayOfYear(date_start[1], date_start[2], date_start[0]);
            string DateNow = DateTime.Now.ToString("yyyy/MM/dd");

            string[] date1 = DateNow.Split('/');

            int z = cal_date.DayOfYear(date1[1], date1[2], date1[0]);

            int sumdate = (365 - y) + 365 + 366 + z;
            return sumdate;

            //cal(y, z);
            /*
            if (period == "daily")
            {
                return cal_daily(y);
            }
            /* if(period = "weekly")
             {

             }
            if (period == "monthly")
            {
                return cal(y, z);
            }
            */
        }
    }
}
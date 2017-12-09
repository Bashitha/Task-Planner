using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    class Program
    {
        private static TimeSpan startTimeOfWorkDay;
        private static TimeSpan stopTimeOfWorkDay;
        private static double noOfWorkingHoursPerDay = 0;
        private static double noOfWorkingHoursToFinishTask = 0;
        private static HashSet<DateTime> holidays = new HashSet<DateTime>();

        //Set the Start time and Stop Time of a Working day
        public static void SetWorkdayStartAndStop(TimeSpan startTimeOfWorkDay, TimeSpan stopTimeOfWorkDay)
        {
            Program.startTimeOfWorkDay = startTimeOfWorkDay;
            Program.stopTimeOfWorkDay = stopTimeOfWorkDay;
            noOfWorkingHoursPerDay =  stopTimeOfWorkDay.TotalHours - startTimeOfWorkDay.TotalHours ;
        }

        //Set a non recurring holiday 
        public static void SetHoliday(DateTime dateTime)
        {
            holidays.Add(dateTime);
            
        }
        //Set recurring holidays
        public static void SetRecurringHoliday(DateTime dateTime)
        {
            holidays.Add(dateTime);
        }

        public static Boolean IsHoliday(DateTime dateToCheck)
        {
            foreach (DateTime holiday in holidays)
            {
                if(dateToCheck.Date == holiday.Date)
                {
                    return true;
                }               
            }
            return false;
        }

        //Get the task finishing date
        public static DateTime GetTaskFinishingDate(DateTime start, double days)
        {
            DateTime dateTime = start;
            DateTime taskFinishingDate;
            TimeSpan finishingTime;
            double noOfMinutesToFinishTask = 0;
            
            noOfWorkingHoursToFinishTask = days * noOfWorkingHoursPerDay;
            double timeRemainInStartDayHours = (stopTimeOfWorkDay.Hours + stopTimeOfWorkDay.Minutes / 60.0) - (start.Hour + start.Minute / 60.0);
            

            while ((noOfWorkingHoursToFinishTask - noOfWorkingHoursPerDay) >= 0)
            {
                //Console.WriteLine(IsHoliday(dateTime));
                if (  dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday && !IsHoliday(dateTime))
                {
                    if (dateTime == start)
                    {
                        noOfWorkingHoursToFinishTask = noOfWorkingHoursToFinishTask - (stopTimeOfWorkDay.TotalHours - dateTime.Hour + dateTime.Minute / 60.0);
                        
                    }
                    else
                    {
                        noOfWorkingHoursToFinishTask = noOfWorkingHoursToFinishTask - noOfWorkingHoursPerDay;
                    }
                    
                }

                dateTime = dateTime.AddDays(1);
                
            }
            noOfMinutesToFinishTask = (noOfWorkingHoursToFinishTask - Math.Truncate(noOfWorkingHoursToFinishTask)) * 60.0;
            finishingTime = startTimeOfWorkDay + TimeSpan.FromHours(noOfWorkingHoursToFinishTask) + TimeSpan.FromMinutes(noOfMinutesToFinishTask);
            taskFinishingDate = dateTime.Date + finishingTime;
            
            return taskFinishingDate;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter start time of the work day as an integer in the 24 hour clock format:");
            var a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter stop time of the work day as an integer in the 24 hour clock format:");
            var b = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter holiday in the format(yyyy mm dd) :");
            var c = Console.ReadLine().Split();
            Console.WriteLine("Enter holiday in the format(mm dd) :");
            var d = Console.ReadLine().Split();
            Console.WriteLine("Enter holiday in the format(yyyy mm dd) :");
            var e = Console.ReadLine().Split();
            Console.WriteLine("Enter holiday in the format(yyyy mm dd) :");
            var f = Console.ReadLine().Split();
            Console.WriteLine("Enter holiday in the format(yyyy mm dd ) :");
            var g = Console.ReadLine().Split();
            Console.WriteLine("Enter the start date of the task (yyyy mm dd hh mm ss) :");
            var h = Console.ReadLine().Split();
            Console.WriteLine("Enter the no. of days to finish the task :");
            var i = Int32.Parse(Console.ReadLine());

            //TaskPlanner.SetWorkdayStartAndStop(new TimeSpan(a, 0, 0), new TimeSpan(b, 0, 0));
            Console.WriteLine(Program.startTimeOfWorkDay);
            Console.WriteLine(Program.stopTimeOfWorkDay);
            Console.WriteLine(Program.noOfWorkingHoursPerDay);

            //TaskPlanner.SetHoliday(new DateTime(Int32.Parse(c[0]), Int32.Parse(c[1]), Int32.Parse(c[2])));
            //TaskPlanner.SetHoliday(new DateTime(Int32.Parse(e[0]), Int32.Parse(e[1]), Int32.Parse(e[2])));
            //TaskPlanner.SetHoliday(new DateTime(Int32.Parse(f[0]), Int32.Parse(f[1]), Int32.Parse(f[2])));
            //TaskPlanner.SetHoliday(new DateTime(Int32.Parse(g[0]), Int32.Parse(g[1]), Int32.Parse(g[2])));
            //TaskPlanner.SetHoliday(new DateTime(DateTime.Now.Year, Int32.Parse(d[0]), Int32.Parse(d[1])));

            foreach (DateTime holiday in holidays)
            {
                Console.WriteLine(holiday);
            }

            Console.WriteLine("task finishing date and time is: ");

            
            
            Console.WriteLine(GetTaskFinishingDate(new DateTime(Int32.Parse(h[0]), Int32.Parse(h[1]), Int32.Parse(h[2]), Int32.Parse(h[3]), Int32.Parse(h[4]), Int32.Parse(h[5])), i).ToString());

        }
    }
}

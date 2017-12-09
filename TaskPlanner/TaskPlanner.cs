using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    public class TaskPlanner
    {
        private static TimeSpan startTimeOfWorkDay;
        private static TimeSpan stopTimeOfWorkDay;
        private static double noOfWorkingHoursPerDay = 0;
        private static double noOfWorkingHoursToFinishTask = 0;
        private static HashSet<DateTime> holidays = new HashSet<DateTime>();

        //Set the Start time and Stop Time of a Working day
        public void SetWorkdayStartAndStop(TimeSpan startTimeOfWorkDay, TimeSpan stopTimeOfWorkDay)
        {
            TaskPlanner.startTimeOfWorkDay = startTimeOfWorkDay;
            TaskPlanner.stopTimeOfWorkDay = stopTimeOfWorkDay;
            noOfWorkingHoursPerDay = stopTimeOfWorkDay.TotalHours - startTimeOfWorkDay.TotalHours;
        }

        //Set a non recurring holiday 
        public void SetHoliday(DateTime dateTime)
        {
            holidays.Add(dateTime);

        }
        //Set recurring holidays
        public void SetRecurringHoliday(DateTime dateTime)
        {
            holidays.Add(dateTime);
        }

        //check whether the date given is a holiday
        public Boolean IsHoliday(DateTime dateToCheck)
        {
            foreach (DateTime holiday in holidays)
            {
                if (dateToCheck.Date == holiday.Date)
                {
                    return true;
                }
            }
            return false;
        }

        //Get the task finishing date
        public DateTime GetTaskFinishingDate(DateTime start, double days)
        {
            DateTime dateTime = start;
            DateTime taskFinishingDate = new DateTime();
            TimeSpan finishingTime;
            double timeRemainInStartDayHours ;
            double noOfMinutesToFinishTask = 0;

            //calculate the no of working hours to finish the task
            noOfWorkingHoursToFinishTask = days * noOfWorkingHoursPerDay;
            
            if (noOfWorkingHoursToFinishTask > 0)
            {
                //calculate the time remaining hours in the starting day if the no of working hours is positive
                if (start.TimeOfDay > stopTimeOfWorkDay)
                {
                    timeRemainInStartDayHours = 0;
                }
                else if (start.TimeOfDay <= startTimeOfWorkDay)
                {
                    timeRemainInStartDayHours = noOfWorkingHoursPerDay;
                }
                else
                {                    
                    timeRemainInStartDayHours = (stopTimeOfWorkDay.Hours + stopTimeOfWorkDay.Minutes / 60.0) - (start.Hour + start.Minute / 60.0);
                }
                
                while ((noOfWorkingHoursToFinishTask - noOfWorkingHoursPerDay) > 0)
                {
                    if (dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday && !IsHoliday(dateTime))
                    {
                        if (dateTime == start)
                        {
                            noOfWorkingHoursToFinishTask = noOfWorkingHoursToFinishTask - timeRemainInStartDayHours;
                        }
                        else
                        {
                            noOfWorkingHoursToFinishTask = noOfWorkingHoursToFinishTask - noOfWorkingHoursPerDay;
                        }

                    }

                    dateTime = dateTime.AddDays(1);

                }

                // to check the last day fr0m the above loop is a holiday
                bool check = true;

                while (check)
                {
                    if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday || IsHoliday(dateTime))
                    {
                        dateTime = dateTime.AddDays(1);
                    }
                    else
                    {
                        check = false;
                    }
                }

                noOfMinutesToFinishTask = (noOfWorkingHoursToFinishTask - Math.Truncate(noOfWorkingHoursToFinishTask)) * 60.0;

                finishingTime = startTimeOfWorkDay + TimeSpan.FromHours((int)noOfWorkingHoursToFinishTask) + TimeSpan.FromMinutes((int)noOfMinutesToFinishTask);

                taskFinishingDate = dateTime.Date + finishingTime;
            }
            else
            {
                noOfWorkingHoursToFinishTask = -1 * noOfWorkingHoursToFinishTask;

                //calculate the time remaining hours in the starting day if the no of working hours is negative
                if (start.TimeOfDay >= stopTimeOfWorkDay)
                {
                    timeRemainInStartDayHours = noOfWorkingHoursPerDay;
                }
                else if (start.TimeOfDay < startTimeOfWorkDay  )
                {
                    timeRemainInStartDayHours = 0;
                } else
                {
                    timeRemainInStartDayHours = (start.Hour + start.Minute / 60.0) - (startTimeOfWorkDay.Hours - startTimeOfWorkDay.Minutes / 60.0)  ;
                }

                while ((noOfWorkingHoursToFinishTask - noOfWorkingHoursPerDay) > 0)
                {
                    if (dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday && !IsHoliday(dateTime))
                    {
                        if (dateTime == start)
                        {
                            noOfWorkingHoursToFinishTask = noOfWorkingHoursToFinishTask - timeRemainInStartDayHours;
                        }
                        else
                        {
                            noOfWorkingHoursToFinishTask = noOfWorkingHoursToFinishTask - noOfWorkingHoursPerDay;
                        }

                    }

                    dateTime = dateTime.AddDays(-1);
                }

                // to check the last day frm the above loop is a holiday
                bool check = true;
                
                while(check)
                {
                    if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday || IsHoliday(dateTime))
                    {                        
                        dateTime = dateTime.AddDays(-1);
                    }
                    else
                    {
                        check = false;
                    }
                }

                noOfMinutesToFinishTask = (noOfWorkingHoursToFinishTask - Math.Truncate(noOfWorkingHoursToFinishTask)) * 60.0;

                finishingTime = stopTimeOfWorkDay - TimeSpan.FromHours((int)noOfWorkingHoursToFinishTask) - TimeSpan.FromMinutes((int)noOfMinutesToFinishTask);

                taskFinishingDate = dateTime.Date + finishingTime;

            }
            

            return taskFinishingDate;
        }
    }
}


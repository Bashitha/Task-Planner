# Task-Planner

As project manager, I want to get an idea of the finishing date of a task based on the estimate (in days) given by the developers. 
Need to create a small class (TaskPlanner) to calculate the exact finishing date and time of a task based on estimate and the start date time 
•	A working day is defined as a day from Monday to Friday which is not a holiday (weekends are not working days)
•	TaskPlanner should have a method to specify the working day start and stop time
o	SetWorkdayStartAndStop(TimeSpan startTime, TimeSpan stopTime)

E.g.
var workdayStartTime = new TimeSpan(8, 0, 0);
var workdayStopTime = new TimeSpan(16, 0, 0);
taskPlanner.SetWorkdayStartAndStop(workdayStartTime, workdayStopTime)

•	TaskPlanner should have 2 methods which tell, which days shall be regarded as holidays
1.	SetHoliday(DateTime dateTime) – setting the Holidays for the workday planner
2.	SetRecurringHoliday(DateTime dateTime) - says the given date is to be regarded as a holiday on the same date every year (in other words disregard the year component).
•	The important method of this class is the one to find the finishing date
DateTime GetTaskFinishingDate(DateTime start, double days)
This method must always return a time (with the date) which is between the two times defined in the method SetWorkdayStartAndStop, even though the startDate need not follow this rule. According to this rule then 2017-12-04 15:07 + 0.25 working days will be 2017-12-05 9:07, and 2017-12-04 4:00 plus 0.5 working days will be 2017-12-04 12:00.   
Following Acceptance tests should be passed at minimum. You can write any number of tests you think is important to construct this class in TDD:
Use the following days as holidays for the test below:
Recurrent holidays: 17/5/2004       Normal Holidays: 27/5/2004
•	24-05-2004 18:05 with the addition of -5.5 working days is 14-05-2004 12:00
•	24-05-2004 19:03 with the addition of 44.723656 working days is 27-07-2004 13:47  
•	24-05-2004 18:03 with the addition of -6.7470217 working days is 13-05-2004 10:02  
•	24-05-2004 08:03 with the addition of 12.782709 working days is 10-06-2004 14:18  
•	24-05-2004 07:03 with addition of 8.276628 working days is 04-06-2004 10:12


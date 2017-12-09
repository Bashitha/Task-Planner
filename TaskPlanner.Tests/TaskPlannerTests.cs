using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;


namespace TaskPlanner.Tests
{
    [TestClass]
    public class TaskPlannerTests
    {
        [TestMethod]
        public void OnGetTaskFinishingDate_WithNegativeFiveWorkingDays()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            taskPlanner.SetWorkdayStartAndStop(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0));
            taskPlanner.SetRecurringHoliday(new DateTime(2004, 5, 17, 0, 0, 0));
            taskPlanner.SetHoliday(new DateTime(2004, 5, 27, 0, 0, 0));

            var start = new DateTime(2004, 5, 24, 18, 5, 0);
            double numberOfDays = -5.5;

            var actual = taskPlanner.GetTaskFinishingDate(start, numberOfDays);
            var expected = new DateTime(2004, 5, 14, 12, 00, 0);

            NUnit.Framework.Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void OnGetTaskFinishingDate_With44WorkingDays()
        {
            TaskPlanner taskPlanner =new TaskPlanner() ;
            taskPlanner.SetWorkdayStartAndStop(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0));
            taskPlanner.SetRecurringHoliday(new DateTime(2004, 5, 17, 0, 0, 0));
            taskPlanner.SetHoliday(new DateTime(2004, 5, 27, 0, 0, 0));

            var start = new DateTime(2004, 5, 24, 19, 3, 0);
            double numberOfDays = 44.723656d;

            var actual = taskPlanner.GetTaskFinishingDate(start, numberOfDays);
            var expected = new DateTime(2004, 7, 27, 13, 47, 0);

            NUnit.Framework.Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void OnGetTaskFinishingDate_WithNegativeSixWorkingDays()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            taskPlanner.SetWorkdayStartAndStop(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0));
            taskPlanner.SetRecurringHoliday(new DateTime(2004, 5, 17, 0, 0, 0));
            taskPlanner.SetHoliday(new DateTime(2004, 5, 27, 0, 0, 0));

            var start = new DateTime(2004, 5, 24, 18, 3, 0);
            double numberOfDays = -6.7470217;

            var actual = taskPlanner.GetTaskFinishingDate(start, numberOfDays);
            var expected = new DateTime(2004, 5, 13, 10, 2, 0);

            NUnit.Framework.Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void OnGetTaskFinishingDate_With12WorkingDays()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            taskPlanner.SetWorkdayStartAndStop(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0));
            taskPlanner.SetRecurringHoliday(new DateTime(2004, 5, 17, 0, 0, 0));
            taskPlanner.SetHoliday(new DateTime(2004, 5, 27, 0, 0, 0));

            var start = new DateTime(2004, 5, 24, 8, 3, 0);
            double numberOfDays = 12.782709d;

            var actual = taskPlanner.GetTaskFinishingDate(start, numberOfDays);
            var expected = new DateTime(2004, 6, 10, 14, 18, 0);

            NUnit.Framework.Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void OnGetTaskFinishingDate_With8WorkingDays()
        {
            TaskPlanner taskPlanner = new TaskPlanner();
            taskPlanner.SetWorkdayStartAndStop(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0));
            taskPlanner.SetRecurringHoliday(new DateTime(2004, 5, 17, 0, 0, 0));
            taskPlanner.SetHoliday(new DateTime(2004, 5, 27, 0, 0, 0));

            var start = new DateTime(2004, 5, 24, 7, 3, 0);
            double numberOfDays = 8.276628d;

            var actual = taskPlanner.GetTaskFinishingDate(start, numberOfDays);
            var expected = new DateTime(2004, 6, 4, 10, 12, 0);

            NUnit.Framework.Assert.AreEqual(expected, actual);

        }
    }
}

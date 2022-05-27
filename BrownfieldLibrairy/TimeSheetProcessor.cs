using System;
using BrownfieldLibrary.Models;

namespace BrownfieldLibrary
{
	public static class TimeSheetProcessor
	{
		public static double GetHoursWorkedForCompany(List<TimeSheetEntryModel> timeSheets, string companyName)
        {
            double hoursWorked = 0;
            for (int i = 0; i < timeSheets.Count; i++)
            {
                if (timeSheets[i].WorkDone.ToLower().Contains(companyName.ToLower()))
                {
                    hoursWorked += timeSheets[i].HoursWorked;
                }
            }
            return hoursWorked;
        }
	}
}


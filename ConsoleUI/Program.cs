using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrownfieldLibrary;
using BrownfieldLibrary.Models;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            double hoursWorked;

            List<TimeSheetEntryModel> timeSheets = LoadTimeSheets();
            List<CustomerModel> customers = DataAccess.GetCustomers();

            customers.ForEach(c => BillCustomer(timeSheets, c));

            hoursWorked = 0;
            for (i = 0; i < timeSheets.Count; i++)
            {
                hoursWorked += timeSheets[i].HoursWorked;
            }
            if (hoursWorked > 40)
            {
                Console.WriteLine("You will get paid $" + (((hoursWorked - 40) * 15) + (40 * 10)) + " for your work.");
            }
            else
            {
                Console.WriteLine("You will get paid $" + hoursWorked * 10 + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static void BillCustomer(List<TimeSheetEntryModel> timeSheets, CustomerModel customer)
        {
            double hoursWorked = TimeSheetProcessor.GetHoursWorkedForCompany(timeSheets, customer.CustomerName);
            Console.WriteLine($"Simulating Sending email to {customer.CustomerName}");
            Console.WriteLine("Your bill is $" + (decimal)hoursWorked * customer.HourlyRateToBill + " for the hours worked.");
        }

        private static List<TimeSheetEntryModel> LoadTimeSheets()
        {
            List<TimeSheetEntryModel> timeSheets = new List<TimeSheetEntryModel>();

            string enterMoreTimeSheets;

            do
            {
                Console.Write("Enter what you did: ");
                string workDone = Console.ReadLine();

                Console.Write("How long did you do it for: ");
                string rawHoursWorked = Console.ReadLine();
                double hoursWorked;
                while (double.TryParse(rawHoursWorked, out hoursWorked) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid number given");
                    Console.Write("How long did you do it for: ");
                    rawHoursWorked = Console.ReadLine();
                }

                TimeSheetEntryModel timeSheet = new TimeSheetEntryModel();
                timeSheet.HoursWorked = hoursWorked;
                timeSheet.WorkDone = workDone;
                timeSheets.Add(timeSheet);

                Console.Write("Do you want to enter more time (yes/no): ");
                enterMoreTimeSheets = Console.ReadLine();

            } while (enterMoreTimeSheets.ToLower() == "yes");

            return timeSheets;
        }
    }
}

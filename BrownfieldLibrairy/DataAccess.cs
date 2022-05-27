using System;
using BrownfieldLibrary.Models;

namespace BrownfieldLibrary
{
	public static class DataAccess
	{
		public static List<CustomerModel> GetCustomers()
        {
			List<CustomerModel> customers = new List<CustomerModel>();
			customers.Add(new CustomerModel { CustomerName = "Acme", HourlyRateToBill = 150 });
			customers.Add(new CustomerModel { CustomerName = "ABC", HourlyRateToBill = 125 });
			return customers;
		}
	}
}


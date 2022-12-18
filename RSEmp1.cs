using System.Net;
using Newtonsoft.Json;
using System;
using RestSharp;
using System.Collections.Generic;

namespace RSEmp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }
    public class Operation
    {
        RestClient restClient = new RestClient("http://localhost:4000");

        public IRestResponse GetEmployeeList()
        {
            RestRequest restRequest = new RestRequest("/employee", Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        public void Display()
        {
            IRestResponse response = GetEmployeeList();
            List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            if (5.Equals(emp.Count))
            {
                Console.WriteLine("Pass");
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("Fail");
                Console.WriteLine("-----------------------------------");
            }
            foreach (Employee e in emp)
            {
                Console.WriteLine("ID:" + e.Id);
                Console.WriteLine("Name:" + e.Name);
                Console.WriteLine("Salary:" + e.Salary);
                Console.WriteLine("\n");
            }
        }
    }
    public class RSEmp1
    {
        static void Main(string[] args)
        {
            Operation obj=new Operation();
            obj.Display();
        }
    }
}

using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace RSEmp3
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
        public void AddMultipleEmployee()
        {
            List<Employee> employee = new List<Employee>();
            employee.Add(new Employee { Name = "FFF", Salary = "7000" });
            employee.Add(new Employee { Name = "GGG", Salary = "8000" });
            employee.Add(new Employee { Name = "HHH", Salary = "9000" });
            employee.Add(new Employee { Name = "III", Salary = "10000" });

            foreach(Employee emp in employee)
            {
                RestRequest rq = new RestRequest("/employee", Method.POST);
                JObject jb = new JObject();
                jb.Add("name", emp.Name);
                jb.Add("salary", emp.Salary);
                rq.AddParameter("application/json", jb, ParameterType.RequestBody);
                IRestResponse rr=restClient.Post(rq);
            }
        }
    }
    public class RSEmp3
    {
        static void Main(string[] args)
        {
            Operation obj=new Operation();
            obj.AddMultipleEmployee();
        }
    }
}

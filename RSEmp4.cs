using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace RSEmp4
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

        public void UpdateEmployeeSalary()
        {
            RestRequest rq=new RestRequest("/employee/109",Method.PUT);
            JObject jb = new JObject();
            jb.Add("name", "III");
            jb.Add("salary", "11000");
            rq.AddOrUpdateParameter("application/json", jb, ParameterType.RequestBody);

            IRestResponse rr=restClient.Put(rq);
        }
    }
    public class RSEmp4
    {
        static void Main(string[] args)
        {
            Operation obj= new Operation();
            obj.UpdateEmployeeSalary();
        }
    }
}

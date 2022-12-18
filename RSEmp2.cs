using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Xml.Linq;

namespace RSEmp2
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

        public void AddEmployee()
        {
            RestRequest restRequest = new RestRequest("/employee", Method.POST);
            JObject jb = new JObject();
            jb.Add("name", "EEE");
            jb.Add("salary", 6000);
            restRequest.AddParameter("application/json", jb, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Post(restRequest);
        }
    }
    public class RSEmp2
    {
        static void Main(string[] args)
        {
            Operation obj= new Operation();
            obj.AddEmployee();
        }
    }
}

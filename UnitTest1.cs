using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using System;

namespace unittests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetItems()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/users", Method.GET);
            var response = client.Execute(request);
            response.Content = response.Content.ToString();
            Console.WriteLine(response.Content.Length);
        }
        [DataRow("1")]
        [DataRow("2")]
        //[DataRow(0)]
        [DataTestMethod]
        public void GetItems2(string filt)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/users", Method.GET);
            request.AddParameter("filter", filt);
            var response = client.Execute(request);
            response.Content = response.Content.ToString();
            Console.WriteLine(response.Content);
        }



        [DataRow("Mark")]
        [DataRow("Carl")]
        [DataTestMethod]
        private void PostItem(string data)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/users", Method.POST);
            request.AddParameter("data", data);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        [DataRow(99,"Mark1")]
        [DataRow(100, "Carl1")]
        [DataTestMethod]
        private static void PutItem(int id, string data)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/users", Method.PUT);
            request.AddParameter("id", id);
            request.AddParameter("data", data);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        [DataRow(100)]
        [DataRow(99)]
        [DataTestMethod]
        private static void DeleteItem(int id)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest($"/users/{id}", Method.DELETE);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}

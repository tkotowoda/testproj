﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using System;

namespace unittests
{
    [TestClass]
    public class UnitTest1
    {
        [Test]
        public void GetItems()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("users", Method.GET);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        [Test]
        public void GetItems2(string filt)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("users", Method.GET);
            request.AddParameter("filter", filt);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        [Test]
        private void PostItem(string data)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("users", Method.POST);
            request.AddParameter("data", data);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        [Test]
        private static void PutItem(int id, string data)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("users", Method.PUT);
            request.AddParameter("id", id);
            request.AddParameter("data", data);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        [Test]
        private static void DeleteItem(int id)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest($"users/{id}", Method.DELETE);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
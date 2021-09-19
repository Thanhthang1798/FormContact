using DemoContactAPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoContactAPI.Classes
{
    public class FechDataClass
    {
        private readonly static string api = "https://5ead24724bf71e00166a0c73.mockapi.io/api";

        public static List<ContactModel> GetData()
        {
            string url = api + "/DemoContact";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var model = JsonConvert.DeserializeObject<List<ContactModel>>(response.Content);
            return model;
        }
        public static object PostData(ContactModel contact)
        {
            string url = api + "/DemoContact";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(contact);
            IRestResponse response = client.Execute(request);
            var model = JsonConvert.DeserializeObject<ContactModel>(response.Content);
            return model;
        }

    }

    public static class JsonResultCommon
    {
        public static object ThanhCong(object data)
        {
            return new
            {
                status = 1,
                data = data,
                error = ""
            };
        }

        public static object ThatBai(string err)
        {
            return new 
            {
                status = 0,
                data = new { },
                error = err
            };
        }
    }
}

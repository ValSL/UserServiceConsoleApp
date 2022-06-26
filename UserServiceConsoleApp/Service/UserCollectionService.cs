using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserServiceConsoleApp.Models;

namespace UserServiceConsoleApp.Service
{
    public class UserCollectionService
    {
        public RestResponse CreateUser(string name, string userStatus)
        {
            var xml = System.IO.File.ReadAllText(@"../../../Assets/CreateUser.xml");
            xml = xml.Replace("{{Name}}", name);
            xml = xml.Replace("{{UserStatusId}}", userStatus);

            var client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator("val", "sal");
            var request = new RestRequest("https://localhost:7032/auth/createuser", Method.Post);
            request.AddHeader("Content-Type", "application/xml");
            request.AddHeader("Accept", "application/xml");
            request.AddParameter("application/xml", xml, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return response;
        }

        public RestResponse RemoveUser(string id)
        {
            var client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator("val", "sal");
            var request = new RestRequest($"https://localhost:7032/auth/removeuser/{id}", Method.Delete);
            RestResponse response = client.Execute(request);
            return response;
        }

        public RestResponse SetStatus(string id, string newStatus)
        {
            var client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator("val", "sal");
            var request = new RestRequest($"https://localhost:7032/auth/setstatus/{id}", Method.Patch);
            var text = File.ReadAllText(@"../../../Assets/json.json");
            var json = JsonSerializer.Deserialize<List<JsonPatchStandart>>(text);
            json[0].value = newStatus;
            json[0].path = "UserStatusId";
            json[0].op = "replace";
            request.AddParameter("application/json", JsonSerializer.Serialize(json), ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            return response;
        }

        public RestResponse UserInfo(string id)
        {
            var client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator("val", "sal");
            var request = new RestRequest($"https://localhost:7032/public/userinfo", Method.Get);
            request.AddQueryParameter("id", id);
            RestResponse response = client.Execute(request);
            return response;
        }
    }
}

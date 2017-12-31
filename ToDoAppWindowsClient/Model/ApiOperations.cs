using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;

namespace ToDoAppWindowsClient.Model
{
    class ApiOperations : IApiOperations
    {
        public RestClient _restClient { get; set; }
        public RestRequest _restReqest { get; set; }
        public string _tableName { get; set; }

        public ApiOperations(string token)
        {
            _restClient = new RestClient("https://kqticr5cwd.execute-api.eu-west-1.amazonaws.com/firstTest");
            _restClient.Authenticator = new JwtAuthenticator(token);
        }

        public async Task<IRestResponse> Delete(ItemRequest item)
        {
            _restReqest = new RestRequest(Method.POST);
            _restReqest.RequestFormat = DataFormat.Json;
            _restReqest.AddBody(item);
            return await _restClient.ExecuteTaskAsync(_restReqest);
        }

        public async Task<IRestResponse> Get(ItemRequest item)
        {

            _restReqest = new RestRequest(Method.POST);
            _restReqest.RequestFormat = DataFormat.Json;
            _restReqest.AddBody(item);
            return await _restClient.ExecuteTaskAsync(_restReqest);
        }

        public async Task<IRestResponse> Put(ItemRequest item)
        {
            _restReqest = new RestRequest(Method.POST);
            _restReqest.RequestFormat = DataFormat.Json;
            _restReqest.AddBody(item);
            return await _restClient.ExecuteTaskAsync(_restReqest);
        }

        public async Task<IRestResponse> Update(ItemRequest item)
        {
            _restReqest = new RestRequest(Method.POST);
            _restReqest.RequestFormat = DataFormat.Json;
            _restReqest.AddBody(item);
            return await _restClient.ExecuteTaskAsync(_restReqest);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace ToDoAppWindowsClient.Model
{
    class ApiOperations : IApiOperations
    {
        public RestClient _restClient { get; set; }
        public RestRequest _restReqest { get; set; }

        public ApiOperations()
        {
            _restClient = new RestClient("https://kqticr5cwd.execute-api.eu-west-1.amazonaws.com/firstTest");
            _restReqest = new RestRequest();
        }

        public Task<IRestResponse> Delete(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<IRestResponse> Get(Item item)
        {
            _restReqest.AddObject(item);
            return await _restClient.ExecuteTaskAsync(_restReqest);
        }

        public Task<IRestResponse> Put(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}

using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppWindowsClient.Model
{
    interface IApiOperations
    {
        RestClient _restClient { get; set; }
        RestRequest _restReqest { get; set; }

        Task<IRestResponse> Delete(Item item);
        Task<IRestResponse> Put(Item item);
        Task<IRestResponse> Update(Item item);
        Task<IRestResponse> Get(Item item);
    }
}

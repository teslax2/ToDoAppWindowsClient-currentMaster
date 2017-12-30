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
        string _tableName { get; set; }

        Task<IRestResponse> Delete(ItemRequest item);
        Task<IRestResponse> Put(ItemRequest item);
        Task<IRestResponse> Update(ItemRequest item);
        Task<IRestResponse> Get(ItemRequest item);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppWindowsClient.Model
{
    class ItemResponse
    {
        public List<Item> Data { get; set; }
        public string Status { get; set; }

        public ItemResponse()
        {
            Data = new List<Item>();
        }
    }
}

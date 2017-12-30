using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppWindowsClient.Model
{
    class ItemRequest
    {
        public string TableName { get; set; }
        public OperationType Operation { get; set; }
        public Item Data { get; set; }

        public ItemRequest()
        {
            Data = new Item();
        }
    }

    enum OperationType
    {
        Delete,
        Get,
        Put,
        Update,
    }
}

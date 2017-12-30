using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppLambda.Model
{
    class Item
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public int Status { get; set; }
        public string User { get; set; }
        public string Alarm { get; set; }

        public Item() { }

        public static string GenerateId()
        {
            var time = System.DateTime.Now.Ticks;
            var random = new System.Random();
            var randomNumber = random.Next(999999);
            return (time * 64 + randomNumber).ToString();
        }

        public Dictionary<string, AttributeValue> GetAttributes()
        {
            var row = new Dictionary<string, AttributeValue>()
            {
                {"TaskId",new AttributeValue{ S = Id}},
                {"Title", new AttributeValue{ S = Title} },
                {"Message", new AttributeValue{ S = Message} },
                {"Date", new AttributeValue{ S = Date} },
                {"Status", new AttributeValue{ N = Status.ToString()} },
                {"User", new AttributeValue{ S = User} },
                {"Alarm", new AttributeValue{ S = Alarm} },
            };
            return row;
        }
    }
}

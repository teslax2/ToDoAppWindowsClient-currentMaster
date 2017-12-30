using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoAppWindowsClient.Model
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

    }
}

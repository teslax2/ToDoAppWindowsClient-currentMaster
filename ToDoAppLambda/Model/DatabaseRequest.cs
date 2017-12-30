using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Threading.Tasks;

namespace ToDoAppLambda.Model
{
    class DatabaseRequest : IDbOperations
    {
        public AmazonDynamoDBClient client { get; set; }
        public string tableName { get; set; }

        public DatabaseRequest(string table)
        {
            client = new AmazonDynamoDBClient();
            tableName = table;
        }

        public async Task<ItemResponse> DeleteItem(Item item)
        {
            var id = item.Id;
            var user = item.User;

            var request = new DeleteItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() {
                    { "User", new AttributeValue { S = user } },
                    { "TaskId", new AttributeValue { S = id } },
            }

            };
            var result = await client.DeleteItemAsync(request);
            return new ItemResponse() { Status = result.HttpStatusCode.ToString() };
        }

        public async Task<ItemResponse> GetItem(Item item)
        {
            var id = item.Id;
            var user = item.User;
            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() {
                    { "User", new AttributeValue { S = user } },
                    { "TaskId", new AttributeValue { S = id } },
                },
                ConsistentRead = true,
            };
            var result = await client.GetItemAsync(request);
            var row = new Item()
            {
                Title = result.Item["Title"].S,
                Date = result.Item["Date"].S,
                Message = result.Item["Message"].S,
                Status = Int32.Parse(result.Item["Status"].N),
                Id = result.Item["TaskId"].S,
                User = result.Item["User"].S,
                Alarm = result.Item["Alarm"].S
            };
            var listOfRows = new List<Item>();
            listOfRows.Add(row);
            return new ItemResponse() { Data = listOfRows, Status = result.HttpStatusCode.ToString() };
        }

        public async Task<ItemResponse> GetItems(Item item)
        {
            var user = item.User;
            var request = new QueryRequest
            {
                TableName = tableName,
                ExpressionAttributeNames = new Dictionary<string, string>(){ { "#U", "User" } },
                KeyConditionExpression = "#U = :v_User",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                    {":v_User", new AttributeValue { S =  user }},
                },
                ConsistentRead = true
            };

            var result = await client.QueryAsync(request);
            var listOfRows = new List<Item>();

            foreach (Dictionary<string, AttributeValue> row in result.Items)
            {
                var rowToAdd = new Item()
                {
                    Title = row["Title"].S,
                    Date = row["Date"].S,
                    Message = row["Message"].S,
                    Status = Int32.Parse(row["Status"].N),
                    Id = row["TaskId"].S,
                    User = row["User"].S,
                    Alarm = row["Alarm"].S
                };
                listOfRows.Add(rowToAdd);
            }
            return new ItemResponse() { Data = listOfRows, Status = result.HttpStatusCode.ToString() };
        }

        public async Task<ItemResponse> PutItem(Item item)
        {
            var request = new PutItemRequest
            {
                TableName = tableName,
                Item = item.GetAttributes()
            };
            var result = await client.PutItemAsync(request);
            return new ItemResponse() { Status = result.HttpStatusCode.ToString() };
        }

        public async Task<ItemResponse> UpdateItem(Item item)
        {
            var id = item.Id;
            var user = item.User;
            var request = new UpdateItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() {
                    { "User", new AttributeValue { S = user } },
                    { "TaskId", new AttributeValue { S = id } },
                },
            };
            var result = await client.UpdateItemAsync(request);
            return new ItemResponse() { Status = result.HttpStatusCode.ToString() };
        }

    }

}

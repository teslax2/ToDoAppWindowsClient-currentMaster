using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoAppWindowsClient.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ToDoAppWindowsClient.ViewModel
{
   class ToDoListViewModel:INotifyPropertyChanged
    {
        private ApiOperations _api = new ApiOperations();
        public event PropertyChangedEventHandler PropertyChanged;
        public string CurrentUser { get; private set; }
        private readonly ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public INotifyCollectionChanged Items { get { return _items; } }
        public Item SingleItem { get; set; } = new Item();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ToDoListViewModel()
        {
            CurrentUser = "wiechu";
            _api._tableName = "ToDoTable";
        }

        public async Task GetToDoTask(string toDoTaskId)
        {
            var itemToGet = new ItemRequest() { Operation = OperationType.Get, TableName = _api._tableName, Data = new Item { User = CurrentUser, Id = toDoTaskId } };
            try
            {
                var response = await _api.Get(itemToGet);
                var itemResponse= JsonConvert.DeserializeObject<ItemResponse>(response.Content);
                if (itemResponse.Data.Count > 0)
                    SingleItem = itemResponse.Data[0];
            }
            catch (Exception ex)
            {
                log.Error("Couldnt get Item" + Environment.NewLine + ex.Message);
            }

        }

        public async Task GetToDoAll()
        {
            var itemToGet = new ItemRequest() { Operation = OperationType.Get, TableName = _api._tableName, Data = new Item { User = CurrentUser} };
            try
            {
                var response = await _api.Get(itemToGet);
                var itemResponse= JsonConvert.DeserializeObject<ItemResponse>(response.Content);
                if(itemResponse.Data.Count > 0)
                {
                    _items.Clear();
                    foreach (var item in itemResponse.Data)
                    {
                        _items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Couldnt get Items" + Environment.NewLine + ex.Message);
            }
        }

        public void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}

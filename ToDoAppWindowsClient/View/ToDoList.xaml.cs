using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoAppWindowsClient.ViewModel;

namespace ToDoAppWindowsClient.View
{
    /// <summary>
    /// Interaction logic for ToDoList.xaml
    /// </summary>
    public partial class ToDoList : Window
    {
        private ToDoListViewModel _viewModel;
        public ToDoList(string token, string user)
        {
            InitializeComponent();
            _viewModel = new ToDoListViewModel(token, user);
            this.DataContext = _viewModel;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.GetToDoAll();
        }
    }
}

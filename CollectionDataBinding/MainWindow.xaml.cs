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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace CollectionDataBinding
{
    

    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users;
        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
            DataContext = users;
        }
        private void LoadUsers()
        { 
            users = new ObservableCollection<User>();
            users.Add(new User() { Name = "Peter Parker" });
            users.Add(new User() { Name = "Tony Stark" });
            users.Add(new User() { Name = "Natasha Romanoff" });
            //usersListBox.ItemsSource = users; 
        }
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User() 
            {
                Name = "Nuevo usuario" };
            users.Add(user);
            usersListBox.SelectedItem = user;
            UpdateView();
        }
        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (usersListBox.SelectedItem != null)
            {
                User user = usersListBox.SelectedItem as User;
                user.Name = userTextBox.Text;
                usersListBox.SelectedItem = user;
                UpdateView();
            }
        }
        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (usersListBox.SelectedItem != null)
            {
                users.Remove(usersListBox.SelectedItem as User);
                //userTextBox.Text = "";
                UpdateView();
            }
        }
        private void UpdateView()
        {
            usersListBox.Items.Refresh();
            if (users.Count > 0)
            {
                deleteUserButton.IsEnabled = true;
                changeUserButton.IsEnabled = true;
            }
            else
            {
                usersListBox.SelectedIndex = -1;
                deleteUserButton.IsEnabled = false;
                changeUserButton.IsEnabled = false;
            }
        }
        private void usersListBox_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            if (usersListBox.SelectedItem != null)
            {
                userTextBox.Text = (usersListBox.SelectedItem as User).Name;
            }
        }

    }
    
}

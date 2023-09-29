using ObligatoriskOpgave_28_08_2023.Model;
using ObligatoriskOpgave_28_08_2023.Model.Decorator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ObligatoriskOpgave_28_08_2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<IMessage> ts = new ObservableCollection<IMessage>();
        ObservableCollection<IMessage> FilteredList = new ObservableCollection<IMessage>();
        MainViewModel MainViewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            
            XMLWorker.ReadMessages2();
            ts = new ObservableCollection<IMessage>(MessageDictionary.Instance.getMessage().Values); 
            DataContext = MainViewModel;
            MessageViewer.ItemsSource = ts;
            

        }
        // i know event handlers er gået af mode, men i cant be assed
        private void listChange(ObservableCollection<IMessage> ts)
        {
            MessageViewer.ItemsSource = ts;
        }

        private void btn_Happy_Click(object sender, RoutedEventArgs e)
        {
            listChange(MessageDictionary.Instance.FilteredMessages(EMood.Happy)); 
        }

        private void btn_Sad_Click(object sender, RoutedEventArgs e)
        {
            listChange(MessageDictionary.Instance.FilteredMessages(EMood.Sad));
        }

        private void btn_Angry_Click(object sender, RoutedEventArgs e)
        {
            listChange(MessageDictionary.Instance.FilteredMessages(EMood.Angry));
        }

        private void btn_Annoyed_Click(object sender, RoutedEventArgs e)
        {
            listChange(MessageDictionary.Instance.FilteredMessages(EMood.Annoying));
        }

        private void btn_Informal_Click(object sender, RoutedEventArgs e)
        {
            listChange(MessageDictionary.Instance.FilteredMessages(EMood.Informal));
        }

        private void btn_CheckOc_Click(object sender, RoutedEventArgs e)
        {
            if (SearchField.Text != "")
            {
                MessageBox.Show (MainViewModel.SearchWord(SearchField.Text));
            }

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            ts.RemoveAt(MessageViewer.SelectedIndex); 

        }
    }
}

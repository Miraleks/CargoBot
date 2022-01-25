using System.Windows;
using System.Windows.Controls;
using CargoBot.Repositories;
using CargoBot.Models;
using CargoBot.ViewModel;

namespace CargoBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllClientsView;
        public static ListView AllShipmentsView;
        public static ListView AllPaymentsView;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllClientsView = ViewAllClients;
            AllShipmentsView = ViewAllShipments;
            AllPaymentsView = ViewAllPayments;
                
        }

    }
}

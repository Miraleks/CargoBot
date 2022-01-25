using CargoBot.Data;
using CargoBot.Models;
using CargoBot.Repositories;
using CargoBot.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Container = CargoBot.Models.Container;

/*  Переопределить столбец Client_code в БД в таблице shipment в clientid
 
 
 */

namespace CargoBot.ViewModel
{
    class DataManageVM : INotifyPropertyChanged
    {
        //все грузы, клиенты, платежи

        private List<Shipment> allShipments = RepositoryDB.GetShipments();
        public List<Shipment> AllShipments
        {
            get { return allShipments; }
            set
            {
                allShipments = value;
                NotifyPropertyChange("AllShipments");
            }
        }

        private List<Client> allClients = RepositoryDB.GetClients();
        public List<Client> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
                NotifyPropertyChange("AllClients");
            }
        }

        private List<Payment> allPayments = RepositoryDB.GetPayments();
        public List<Payment> AllPayments
        {
            get { return allPayments; }
            set
            {
                allPayments = value;
                NotifyPropertyChange("AllClients");
            }
        }

        private List<Employee> allEmployees = RepositoryDB.GetEmployees();
        public List<Employee> AllEmployees
        {
            get { return allEmployees; }
            set
            {
                allEmployees = value;
                NotifyPropertyChange("AllEmployees");
            }
        }
        //все контейнеры
        private List<Container> allContainers = RepositoryDB.GetContainers();
        public List<Container> AllContainers
        {
            get { return allContainers; }
            set
            {
                allContainers = value;
                NotifyPropertyChange("AllEmployees");
            }
        }
        //все склады
        private List<Warehouse> allWarehouses = RepositoryDB.GetWarehouses();
        public List<Warehouse> AllWarehouses
        {
            get { return allWarehouses; }
            set
            {
                allWarehouses = value;
                NotifyPropertyChange("AllEmployees");
            }
        }



        #region свойства для грузов
        public static int Client_code { get; set; }
        public static string Name { get; set; }
        public static int Place { get; set; }
        public static double Weight { get; set; }
        public static double Value { get; set; }
        public static decimal Price { get; set; }
        public static int WarehouseId { get; set; }
        public static System.DateTime DateRecieve { get; set; }
        public static System.DateTime DateIssue { get; set; }
        public static int ContId { get; set; }
        public static int EmployeeId { get; set; }
        #endregion

        #region свойства для клиентов
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static int UserId { get; set; }
        public static string E_Mail { get; set; }
        public static string Phone { get; set; }
        #endregion


        //методы добавления данных в БД

        private RelayCommand addNewShipment;
        public RelayCommand AddNewShipment
        {
            get
            {
                return addNewShipment ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (Client_code == 0)
                    {
                        SetRedBlockControl(wnd, "CodeBlock");
                    }
                    if (Place == 0)
                    {
                        SetRedBlockControl(wnd, "PlaceBlock");
                    }
                    if (Weight == 0)
                    {
                        SetRedBlockControl(wnd, "WeightBlock");
                    }
                    if (Value == 0)
                    {
                        SetRedBlockControl(wnd, "ValueBlock");
                    }
                    if (WarehouseId == 0)
                    {
                        MessageBox.Show("Укажите склад");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateShipment(Client_code, Name, Place, Weight, Value, Price, WarehouseId, DateRecieve, DateIssue, ContId, EmployeeId);
                        ShowMessageToUser(resultStr);
                        UpdateAllData();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                });
            }
        }

        private RelayCommand addNewClient;
        public RelayCommand AddNewClient
        {
            get
            {
                return addNewClient ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (Client_code == 0)
                    {
                        SetRedBlockControl(wnd, "ClientCodeBlock");
                    }
                    else if (Phone == null)
                    {
                        SetRedBlockControl(wnd, "PhoneBlock");
                    }
                    else if (FirstName == null)
                    {
                        SetRedBlockControl(wnd, "FirstNameBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateClient(Client_code, FirstName, LastName, E_Mail, Phone, UserId);
                        ShowMessageToUser(resultStr);
                        UpdateAllData();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                });
            }
        }


        //методы открытия окон
        private void OpenAddShipmentWindowMethod()
        {
            AddNewShipmentWindow newShipmentWindow = new AddNewShipmentWindow();
            SetCenterPositionAndOpen(newShipmentWindow);
        }
        private void OpenAddClientWindowMethod()
        {
            AddNewClientWindow newClientWindow = new AddNewClientWindow();
            SetCenterPositionAndOpen(newClientWindow);
        }
        private void OpenAddPaymentWindowMethod()
        {
            AddNewPaymentWindow newPaymentWindow = new AddNewPaymentWindow();
            SetCenterPositionAndOpen(newPaymentWindow);
        }

        //окна редактирования
        private void OpenEditShipmentWindowMethod()
        {
            EditShipmentWindow editShipmentWindow = new EditShipmentWindow();
            SetCenterPositionAndOpen(editShipmentWindow);
        }
        private void OpenEditClientWindowMethod()
        {
            EditClientWindow editClientWindow = new EditClientWindow();
            SetCenterPositionAndOpen(editClientWindow);
        }
        private void OpenEditPaymentWindowMethod()
        {
            EditPaymentWindow editPaymentWindow = new EditPaymentWindow();
            SetCenterPositionAndOpen(editPaymentWindow);
        }

        //команды открытия
        private RelayCommand openAddNewShipmentWnd;

        public RelayCommand OpenAddNewShipmentWnd
        {
            get
            {
                return openAddNewShipmentWnd ?? new RelayCommand(obj =>
                {
                    OpenAddShipmentWindowMethod();
                });
            }
        }

        private RelayCommand openAddNewClientWnd;

        public RelayCommand OpenAddNewClientWnd
        {
            get
            {
                return openAddNewClientWnd ?? new RelayCommand(obj =>
                {
                    OpenAddClientWindowMethod();
                });
            }
        }

        private RelayCommand openAddNewPaymentWnd;

        public RelayCommand OpenAddNewPaymentWnd
        {
            get
            {
                return openAddNewPaymentWnd ?? new RelayCommand(obj =>
                {
                    OpenAddPaymentWindowMethod();
                });
            }
        }


        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        private void SetNullValuesToProperties()
        {
            Client_code = 0;
            Name = null;
            Place = 0;
            Weight = 0;
            Value = 0;
            Price = 0;
            WarehouseId = 0;
            DateRecieve = default;
            DateIssue = default;
            ContId = 0;
            EmployeeId = 0;

            FirstName = null;
            LastName = null;
            UserId = 0;
            E_Mail = null;
            Phone = null;
    }
        private void UpdateAllData()
        {
            UpdateAllClientsView();
            UpdateAllShipmentsView();
            UpdateAllPaymentsView();
        }

        private void UpdateAllClientsView()
        {
            AllClients = RepositoryDB.GetClients();
            MainWindow.AllClientsView.ItemsSource = null;
            MainWindow.AllClientsView.Items.Clear();
            MainWindow.AllClientsView.ItemsSource = AllClients;
            MainWindow.AllClientsView.Items.Refresh();

        }
        private void UpdateAllShipmentsView()
        {
            AllShipments = RepositoryDB.GetShipments();
            MainWindow.AllShipmentsView.ItemsSource = null;
            MainWindow.AllShipmentsView.Items.Clear();
            MainWindow.AllShipmentsView.ItemsSource = AllShipments;
            MainWindow.AllShipmentsView.Items.Refresh();

        }
        private void UpdateAllPaymentsView()
        {
            AllPayments = RepositoryDB.GetPayments();
            MainWindow.AllPaymentsView.ItemsSource = null;
            MainWindow.AllPaymentsView.Items.Clear();
            MainWindow.AllPaymentsView.ItemsSource = AllPayments;
            MainWindow.AllPaymentsView.Items.Refresh();

        }

        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }

        public event PropertyChangedEventHandler PropertyChanged;
            
        private void NotifyPropertyChange(String propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void SetRedBlockControl(Window window, string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            if (block != null)
            {
                block.BorderBrush = Brushes.Red;
            }
        }

    }
}

using CargoBot.ViewModel;
using System.Windows;


namespace CargoBot.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewShipment.xaml
    /// </summary>
    public partial class AddNewShipmentWindow : Window
    {
        public AddNewShipmentWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}

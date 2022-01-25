using System.Windows;
using CargoBot.ViewModel;



namespace CargoBot.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {
        public AddNewClientWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
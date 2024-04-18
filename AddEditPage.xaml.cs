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

namespace fit
{
    /// <summary>
    /// Interaction logic for AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Kvitancya _currentKvitancya = new Kvitancya();

        public AddEditPage(Kvitancya selectedKvitancya)
        {
            InitializeComponent();

            if (selectedKvitancya != null)
                _currentKvitancya = selectedKvitancya;

            DataContext = _currentKvitancya;
            ComboUsluga.ItemsSource = FitEntities.GetContext().Usluga.ToList();
            ComboUsluga.SelectedValue = 1;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentKvitancya.FioClienta))
                errors.AppendLine("Укажите ФИО клиента");
            if (_currentKvitancya.Usluga1 == null)
                errors.AppendLine("Выберите услугу");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentKvitancya.Id == 0)
                FitEntities.GetContext().Kvitancya.Add(_currentKvitancya);
            try
            {
                FitEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ComboUsluga_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboUsluga.SelectedItem != null)
            {
                var selectedService = (Usluga)ComboUsluga.SelectedItem;
                TextBlockStoimost.Text = selectedService.Stoimost.ToString(); // Assuming Cost is a property of your Service entity
            }
        }
    }
}
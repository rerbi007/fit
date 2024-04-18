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
    /// Interaction logic for KvitancyaPage.xaml
    /// </summary>
    public partial class KvitancyaPage : Page
    {
        public KvitancyaPage()
        {
            InitializeComponent();
            //DGridKvitancya.ItemsSource = FitEntities.GetContext().Kvitancya.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var kvitancyasForRemoving = DGridKvitancya.SelectedItems.Cast<Kvitancya>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {kvitancyasForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (Kvitancya item in kvitancyasForRemoving)
                    {
                        FitEntities.GetContext().Kvitancya.Remove(item);
                    }
                    //FitEntities.GetContext().Kvitancya.RemoveRange(kvitancyasForRemoving);
                    FitEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridKvitancya.ItemsSource = FitEntities.GetContext().Kvitancya.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FitEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridKvitancya.ItemsSource = FitEntities.GetContext().Kvitancya.ToList();
            }
        }
    }
}

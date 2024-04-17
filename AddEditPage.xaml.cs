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

            

            ComboUsluga.SelectedValue = 1;

            FitEntities fitContext = new FitEntities();
            ComboUsluga.ItemsSource = fitContext.Uslugas.ToList();

            //List<Kvitancya> Usluga = FitEntities.GetContext().Kvitancyas.ToList();
            //ComboUsluga.ItemsSource = Usluga;
            ComboUsluga.SelectedIndex = 2;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

//ComboUsluga.ItemsSource = FitEntities.GetContext().Kvitancyas.ToList();
//private static FitEntities _context;
//public static FitEntities GetContext()
//{
//    if (_context == null)
//        _context = new FitEntities();
//    return _context;
//}
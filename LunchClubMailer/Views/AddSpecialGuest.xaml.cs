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

namespace LunchClubMailer
{
    /// <summary>
    /// Interaction logic for AddSpecialGuest.xaml
    /// </summary>
    public partial class AddSpecialGuest : Window
    {
        private object model;
        public AddSpecialGuest(AddSpecialGuestModel model)
        {
            InitializeComponent();
            this.model = model;
            this.DataContext = model;
            model.requestClose += HandleRequestClose;
        }

        public AddSpecialGuest(EditSpecialGuestModel model)
        {
            InitializeComponent();
            this.model = model;
            this.DataContext = model;
            model.requestClose += HandleRequestClose;
        }

        private void HandleRequestClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}

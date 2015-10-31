using LunchClubMailer.Models;
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

namespace LunchClubMailer.Views
{
    /// <summary>
    /// Interaction logic for ImportExport.xaml
    /// </summary>
    public partial class ImportExport : Window
    {
        private ImportExportModel model;
        public ImportExport(ImportExportModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            this.model = model;
            model.requestClose += HandleRequestClose;
        }

        private void HandleRequestClose(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

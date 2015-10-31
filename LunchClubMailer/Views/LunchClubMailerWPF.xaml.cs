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
  /// Interaction logic for LunchClubMailerWPF.xaml
  /// </summary>
  public partial class LunchClubMailerWPF : Window
  {

    private LunchClubModel model;
    public LunchClubMailerWPF(LunchClubModel model)
    {
      InitializeComponent();
      this.model = model;
      this.DataContext = model;
    }


 
  }
}

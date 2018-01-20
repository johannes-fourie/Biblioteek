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

namespace Biblioteek.Katalogus
{
    /// <summary>
    /// Interaction logic for EditBoek.xaml
    /// </summary>
    public partial class EditBoek : UserControl
    {
        public EditBoek()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            (this.DataContext as EditBoekViewModel).Initialize();
        }
    }
}

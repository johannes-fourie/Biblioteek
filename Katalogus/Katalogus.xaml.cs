using System.Windows.Controls;

namespace Biblioteek.Katalogus
{
    /// <summary>
    /// Interaction logic for KatalogusView.xaml
    /// </summary>
    public partial class KatalogusView : UserControl
    {
        public KatalogusView() => InitializeComponent();

        private void UserControl_Initialized(object sender, System.EventArgs e)
        {
            (this.DataContext as KatalogusViewModel).Initialize();
        }
    }
}
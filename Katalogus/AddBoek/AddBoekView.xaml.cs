using Biblioteek.Types;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Biblioteek.Katalogus
{
    /// <summary>
    /// Interaction logic for AddBoek.xaml
    /// </summary>
    public partial class AddBoekView : UserControl
    {
        public AddBoekView() => InitializeComponent();

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            (this.DataContext as AddBoekViewModel).Initialize();
        }
    }
}
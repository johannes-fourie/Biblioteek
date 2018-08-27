using Biblioteek.Types;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Biblioteek.Katalogus
{
    /// <summary>
    /// Interaction logic for AddBoek.xaml
    /// </summary>
    public partial class AddBoek : UserControl
    {
        public AddBoek() => InitializeComponent();

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            (this.DataContext as AddBoekViewModel).Initialize();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (this.DataContext as AddBoekViewModel).Refresh();
        }
    }
}
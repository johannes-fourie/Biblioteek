using Biblioteek.Types;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

            this.SetBinding(
                dp: LastAddedBoekNommerProperty,
                binding: new Binding("LastAddedBoekNommer") { Mode = BindingMode.TwoWay });
        }

        public static readonly DependencyProperty LastAddedBoekNommerProperty =
            DependencyProperty.Register(
                name: "LastAddedBoekNommer",
                propertyType: typeof(BoekNommer),
                ownerType: typeof(AddBoek));

        public BoekNommer LastAddedBoekNommer
        {
            get => (BoekNommer)GetValue(LastAddedBoekNommerProperty);

            set => SetValue(LastAddedBoekNommerProperty, value);
        }
    }
}
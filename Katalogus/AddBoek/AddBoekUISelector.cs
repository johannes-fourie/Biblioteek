using Biblioteek.Types;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Biblioteek.Katalogus.AddBoek
{
    public class AddBoekUISelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var uiElements = new ResourceDictionary()
            {
                Source = new Uri("/UIElements.xaml", UriKind.RelativeOrAbsolute)
            };

            DataTemplate dataTemplate;

            switch (item)
            {
                case Tietel t:
                    dataTemplate = uiElements["EditTietel"] as DataTemplate;
                    break;

                default:
                    throw new KeyNotFoundException($"Type [{item.GetType().FullName}] does not match a UI element.");
            }

            return dataTemplate;
        }
    }
}
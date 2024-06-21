using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HospitalManagementSystem.TextBoxFocusBehavior
{
    public static class TextBoxFocusBehavior
    {
        public static readonly DependencyProperty PlaceHolderTextProperty =
            DependencyProperty.RegisterAttached(
                "PlaceHolderText",
                typeof(string),
                typeof(TextBoxFocusBehavior),
                new PropertyMetadata(string.Empty, OnPlaceHolderTextChanged));

        public static string GetPlaceholderText(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceHolderTextProperty);
        }
        public static void SetPlaceholderText(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceHolderTextProperty, value);
        }
        private static void OnPlaceHolderTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if(obj is TextBox textbox)
            {
                textbox.GotFocus += TextBox_GotFocus;
                textbox.LostFocus += TextBox_LostFocus;
            }
        }
        
        private static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textbox && textbox.Text == GetPlaceholderText(textbox))
            {
                textbox.Text = string.Empty;
            }
        }

        private static void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox textbox && textbox.Text == string.Empty)
            {
                textbox.Text = GetPlaceholderText(textbox);
            }
        }
        
    }
}

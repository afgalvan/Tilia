using System;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Atomic.Input.Required
{
    public partial class RequiredTextFieldUserControl : UserControl
    {
        public RequiredTextFieldUserControl()
        {
            InitializeComponent();
        }

        public string FieldText
        {
            get => (string)GetValue(FieldTextProperty);
            set => SetValue(FieldTextProperty, value);
        }

        public string TextFieldFloatingHint
        {
            get => (string)GetValue(TextFieldFloatingHintProperty);
            set => SetValue(TextFieldFloatingHintProperty, value);
        }

        public string TextFieldWidth
        {
            get => (string)GetValue(TextFieldWidthProperty);
            set => SetValue(TextFieldWidthProperty, value);
        }

        public string TextFieldFontSize
        {
            get => (string)GetValue(TextFieldFontSizeProperty);
            set => SetValue(TextFieldFontSizeProperty, value);
        }

        public static readonly DependencyProperty FieldTextProperty =
            DependencyProperty.Register("FieldText", typeof(string), typeof(RequiredTextFieldUserControl), new PropertyMetadata(""));

        public static readonly DependencyProperty TextFieldFloatingHintProperty =
            DependencyProperty.Register("TextFieldFloatingHint", typeof(string), typeof(RequiredTextFieldUserControl), new PropertyMetadata(""));

        public static readonly DependencyProperty TextFieldWidthProperty =
            DependencyProperty.Register("TextFieldWidth", typeof(string), typeof(RequiredTextFieldUserControl), new PropertyMetadata("200"));

        public static readonly DependencyProperty TextFieldFontSizeProperty =
            DependencyProperty.Register("TextFieldFontSize", typeof(string), typeof(RequiredTextFieldUserControl), new PropertyMetadata("15"));
    }
}

using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Presentation.Components.Atomic.Input
{
    public partial class ComboBoxUserControl : UserControl
    {
        public ComboBoxUserControl()
        {
            InitializeComponent();
            SetDefaultComboBox();
            ItemSourceBinding();
        }

        private void SetDefaultComboBox()
        {
            ComboBoxWidth = "200";
            ComboBoxFontSize = "15";
            ComboBoxHeight = "46";
        }

        private void ItemSourceBinding()
        {
            Binding binding = new("ComboBoxItemsSource")
            {
                Source = this
            };
            _ = ComboBoxInput.SetBinding(ItemsControl.ItemsSourceProperty, binding);
        }

        public string Text
        {
            get => ComboBoxInput.Text;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                ComboBoxInput.Text = Text;
            }
        }

        public string ComboBoxHint
        {
            get => (string)GetValue(ComboBoxHintProperty);
            set => SetValue(ComboBoxHintProperty, value);
        }

        public string ComboBoxWidth
        {
            get => (string)GetValue(ComboBoxWidthProperty);
            set => SetValue(ComboBoxWidthProperty, value);
        }

        public string ComboBoxFontSize
        {
            get => (string)GetValue(ComboBoxFontSizeProperty);
            set => SetValue(ComboBoxFontSizeProperty, value);
        }

        public IEnumerable ComboBoxItemsSource
        {
            get => (IEnumerable)GetValue(ComboBoxItemsSourceProperty);
            set => SetValue(ComboBoxItemsSourceProperty, value);
        }

        public string ComboBoxHeight
        {
            get => (string)GetValue(ComboBoxHeightProperty);
            set => SetValue(ComboBoxHeightProperty, value);
        }

        public static readonly DependencyProperty ComboBoxHintProperty =
            DependencyProperty.Register("ComboBoxHint", typeof(string), typeof(ComboBoxUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ComboBoxWidthProperty =
            DependencyProperty.Register("ComboBoxWidth", typeof(string), typeof(ComboBoxUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ComboBoxHeightProperty =
            DependencyProperty.Register("ComboBoxHeight", typeof(string), typeof(ComboBoxUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ComboBoxFontSizeProperty =
            DependencyProperty.Register("ComboBoxFontSize", typeof(string), typeof(ComboBoxUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ComboBoxItemsSourceProperty =
            DependencyProperty.Register("ComboBoxItemsSource", typeof(IEnumerable), typeof(ComboBoxUserControl), new PropertyMetadata(null));
    }
}

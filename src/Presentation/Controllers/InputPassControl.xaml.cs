using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Client_Holu_Win.src.Presentation.Controllers
{
    public partial class InputPassControl : UserControl
    {
        public InputPassControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        #region InputLabel (Dependency Property)

        public static readonly DependencyProperty InputLabelProperty =
            DependencyProperty.Register("InputLabel", typeof(string), 
                typeof(InputPassControl), 
                new PropertyMetadata(string.Empty)
                );

        public string InputLabel
        {
            get { return (string)GetValue(InputLabelProperty); }
            set { SetValue(InputLabelProperty, value); }
        }
        #endregion

        #region InputIcon (Dependency Property)
        public static readonly DependencyProperty InputIconProperty =
            DependencyProperty.Register("InputIcon", typeof(string), typeof(InputPassControl), new PropertyMetadata(string.Empty));

        public string InputIcon
        {
            get { return (string)GetValue(InputIconProperty); }
            set { SetValue(InputIconProperty, value); }
        }

        #endregion


        #region InputWidth (Dependency Property)

        public static readonly DependencyProperty InputWidthProperty =
            DependencyProperty.Register(
                "InputWidth",
                typeof(double),
                typeof(InputPassControl),
                new PropertyMetadata(400.0, OnInputWidthChanged)
            );

        public double InputWidth
        {
            get { return (double)GetValue(InputWidthProperty); }
            set { SetValue(InputWidthProperty, value); }
        }

        public double InputConWidth => InputWidth - 100;

        private static void OnInputWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var controller = (InputPassControl)d;
            controller.OnPropertyChanged(nameof(InputConWidth));
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void TogglePasswordVisibility_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                PasswordTextBox.Text = PasswordBox.Password;
                PasswordBox.Visibility = Visibility.Collapsed;
                PasswordTextBox.Visibility = Visibility.Visible;

                ToggleIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff;
            }
            else
            {
                PasswordBox.Password = PasswordTextBox.Text;
                PasswordBox.Visibility = Visibility.Visible;
                PasswordTextBox.Visibility = Visibility.Collapsed;

                ToggleIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye;
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                PasswordTextBox.Text = PasswordBox.Password;
            }
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordTextBox.Visibility == Visibility.Visible)
            {
                PasswordBox.Password = PasswordTextBox.Text;
            }
        }

    }
}

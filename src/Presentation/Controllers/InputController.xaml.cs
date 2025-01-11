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
    public partial class InputController : UserControl
    {
        public InputController()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #region InputLabel (Dependency Property)

        public static readonly DependencyProperty InputLabelProperty =
            DependencyProperty.Register("InputLabel", typeof(string), typeof(InputController), new PropertyMetadata(string.Empty));

        public string InputLabel
        {
            get { return (string)GetValue(InputLabelProperty); }
            set { SetValue(InputLabelProperty, value); }
        }
        #endregion

        #region InputIcon (Dependency Property)
        public static readonly DependencyProperty InputIconProperty = 
            DependencyProperty.Register("InputIcon", typeof(string), typeof(InputController), new PropertyMetadata(string.Empty));

        public string InputIcon
        {
            get { return (string)GetValue(InputIconProperty); }
            set { SetValue(InputIconProperty, value);}
        }

        #endregion

        #region InputWidth (Dependency Property)

        public static readonly DependencyProperty InputWidthProperty =
            DependencyProperty.Register(
                "InputWidth", 
                typeof(double), 
                typeof(InputController), 
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
            var controller = (InputController)d;
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
    }
}

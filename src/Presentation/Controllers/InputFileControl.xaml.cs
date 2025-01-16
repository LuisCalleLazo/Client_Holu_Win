using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Client_Holu_Win.src.Presentation.Controllers
{
    /// <summary>
    /// Interaction logic for InputFileControl.xaml
    /// </summary>
    public partial class InputFileControl : UserControl
    {
        public InputFileControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #region InputLabel (Dependency Property)

        public static readonly DependencyProperty InputLabelProperty =
            DependencyProperty.Register("InputLabel", typeof(string), typeof(InputFileControl), new PropertyMetadata(string.Empty));

        public string InputLabel
        {
            get { return (string)GetValue(InputLabelProperty); }
            set { SetValue(InputLabelProperty, value); }
        }
        #endregion

        #region InputIcon (Dependency Property)
        public static readonly DependencyProperty InputIconProperty =
            DependencyProperty.Register("InputIcon", typeof(string), typeof(InputFileControl), new PropertyMetadata(string.Empty));

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
                typeof(InputFileControl)
            );

        public double InputWidth
        {
            get { return (double)GetValue(InputWidthProperty); }
            set { SetValue(InputWidthProperty, value); }
        }
        #endregion

        private void SelectImageClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                ImagePreview.ImageSource = bitmap;
            }
        }
    }
}

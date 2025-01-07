
using System.Windows;
using System.Windows.Controls;

namespace Client_Holu_Win.src.Presentation.Pages.Authentication
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private Frame _mainFrame;
        public RegisterPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LoginPage(_mainFrame));
        }
    }
}

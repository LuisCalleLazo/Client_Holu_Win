using System.Windows;
using System.Windows.Controls;

namespace Client_Holu_Win.src.Presentation.Pages.Authentication
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private Frame _mainFrame;
        public LoginPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }
        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this);
            var mainWindow = new MainWindow();

            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            
            currentWindow?.Close();
        }
        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new RegisterPage(_mainFrame));
        }
    }
}

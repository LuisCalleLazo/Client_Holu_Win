using System.Text;
using System.Windows;
using Client_Holu_Win.src.Presentation.Pages.Authentication;

namespace Client_Holu_Win.src.Presentation.Views
{
    public partial class Authentication : Window
    {

        public Authentication()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage(MainFrame));
        }
    }
}

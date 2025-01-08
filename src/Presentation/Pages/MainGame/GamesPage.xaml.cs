using System;
using System.Collections.Generic;
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

namespace Client_Holu_Win.src.Presentation.Pages.MainGame
{
    /// <summary>
    /// Interaction logic for GamesPage.xaml
    /// </summary>
    public partial class GamesPage : Page
    {
        private Frame _mainFrame;
        public GamesPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }
    }
}

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

namespace Client_Holu_Win.src.Presentation.Controllers
{
    public partial class NavItemControl : UserControl
    {
        public NavItemControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        #region NavText (Dependency Property)

        public static readonly DependencyProperty NavTextProperty =
            DependencyProperty.Register("NavText", typeof(string), typeof(NavItemControl), new PropertyMetadata(string.Empty));

        public string NavText
        {
            get { return (string)GetValue(NavTextProperty); }
            set { SetValue(NavTextProperty, value); }
        }
        #endregion

        #region NavBackground (Dependency Property)
        public static readonly DependencyProperty NavBackgroundProperty =
            DependencyProperty.Register("NavBackground", typeof(Brush), typeof(NavItemControl), new PropertyMetadata(Brushes.Gray));

        public Brush NavBackground
        {
            get { return (Brush)GetValue(NavBackgroundProperty); }
            set { SetValue(NavBackgroundProperty, value); }
        }
        #endregion

        #region NavForeground (Dependency Property)
        public static readonly DependencyProperty NavForegroundProperty =
            DependencyProperty.Register("NavForeground", typeof(Brush), typeof(NavItemControl), new PropertyMetadata(Brushes.White));

        public Brush NavForeground
        {
            get { return (Brush)GetValue(NavForegroundProperty); }
            set { SetValue(NavForegroundProperty, value); }
        }
        #endregion


        #region NavIcon (Dependency Property)
        public static readonly DependencyProperty NavIconProperty =
            DependencyProperty.Register("NavIcon", typeof(string), 
                typeof(NavItemControl), 
                new PropertyMetadata(string.Empty));

        public string NavIcon
        {
            get { return (string)GetValue(NavIconProperty); }
            set { SetValue(NavIconProperty, value); }
        }

        #endregion


        #region NavWidth (Dependency Property)
        public static readonly DependencyProperty NavWidthProperty =
            DependencyProperty.Register("NavWidth", typeof(double), typeof(NavItemControl), new PropertyMetadata(200.0));

        public double NavWidth
        {
            get { return (double)GetValue(NavWidthProperty); }
            set { SetValue(NavWidthProperty, value); }
        }
        #endregion

        #region NavHeight (Dependency Property)
        public static readonly DependencyProperty NavHeightProperty =
            DependencyProperty.Register("NavHeight", typeof(double), typeof(NavItemControl), new PropertyMetadata(50.0));

        public double NavHeight
        {
            get { return (double)GetValue(NavHeightProperty); }
            set { SetValue(NavHeightProperty, value); }
        }
        #endregion

        public static readonly RoutedEvent NavClickEvent =
            EventManager.RegisterRoutedEvent("NavClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NavItemControl));

        public event RoutedEventHandler NavClick
        {
            add { AddHandler(NavClickEvent, value); }
            remove { RemoveHandler(NavClickEvent, value); }
        }

        private void OnNavClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(NavClickEvent));
        }
    }
}


using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Client_Holu_Win.src.Presentation.Controllers
{
    public partial class BtnAccept : UserControl
    {
        public BtnAccept()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #region ButtonText (Dependency Property)

        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(BtnAccept), new PropertyMetadata(string.Empty));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }
        #endregion

        #region ButtonBackground (Dependency Property)
        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(BtnAccept), new PropertyMetadata(Brushes.Gray));

        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }
        #endregion

        #region ButtonForeground (Dependency Property)
        public static readonly DependencyProperty ButtonForegroundProperty =
            DependencyProperty.Register("ButtonForeground", typeof(Brush), typeof(BtnAccept), new PropertyMetadata(Brushes.White));

        public Brush ButtonForeground
        {
            get { return (Brush)GetValue(ButtonForegroundProperty); }
            set { SetValue(ButtonForegroundProperty, value); }
        }
        #endregion

        #region ButtonWidth (Dependency Property)
        public static readonly DependencyProperty ButtonWidthProperty =
            DependencyProperty.Register("ButtonWidth", typeof(double), typeof(BtnAccept), new PropertyMetadata(200.0));

        public double ButtonWidth
        {
            get { return (double)GetValue(ButtonWidthProperty); }
            set { SetValue(ButtonWidthProperty, value); }
        }
        #endregion

        #region ButtonHeight (Dependency Property)
        public static readonly DependencyProperty ButtonHeightProperty =
            DependencyProperty.Register("ButtonHeight", typeof(double), typeof(BtnAccept), new PropertyMetadata(50.0));

        public double ButtonHeight
        {
            get { return (double)GetValue(ButtonHeightProperty); }
            set { SetValue(ButtonHeightProperty, value); }
        }
        #endregion

        public static readonly RoutedEvent ButtonClickEvent =
            EventManager.RegisterRoutedEvent("ButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BtnAccept));

        public event RoutedEventHandler ButtonClick
        {
            add { AddHandler(ButtonClickEvent, value); }
            remove { RemoveHandler(ButtonClickEvent, value); }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonClickEvent));
        }
    }
}

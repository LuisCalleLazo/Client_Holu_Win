using Client_Holu_Win.src.Presentation.Pages.MainGame;
using Client_Holu_Win.src.Presentation.Views;
using System.Windows;

namespace Client_Holu_Win;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new ProfilePage(MainFrame));
    }

    private void NavForumsPage(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new ForumsPage(MainFrame));
        Console.WriteLine("IR A FOROS");
    }
    private void NavHistoryPage(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new HistoryPage(MainFrame));
    }
    private void NavGamesPage(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new GamesPage(MainFrame));
    }
    private void NavProfilePage(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new ProfilePage(MainFrame));
    }

    private void NavStatisticsPage(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new StatisticsPage(MainFrame));
    }
    private void CloseSession(object sender, RoutedEventArgs e)
    {
        var currentWindow = GetWindow(this);
        var authWindow = new Authentication();

        Application.Current.MainWindow = authWindow;
        authWindow.Show();

        currentWindow?.Close();
    }
}
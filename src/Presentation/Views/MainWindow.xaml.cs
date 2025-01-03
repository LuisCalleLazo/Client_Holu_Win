using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client_Holu_Win;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Lista de partidas
    public ObservableCollection<Game> Games { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        Games = new ObservableCollection<Game>();
        GameList.ItemsSource = Games;
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        string gameName = GameNameTextBox.Text;
        if (string.IsNullOrWhiteSpace(gameName))
        {
            MessageBox.Show("Please enter a game name.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        Games.Add(new Game { Name = gameName, CreatedAt = DateTime.Now });
        GameNameTextBox.Clear();
    }

    private void JoinButton_Click(object sender, RoutedEventArgs e)
    {
        if (GameList.SelectedItem is Game selectedGame)
        {
            MessageBox.Show($"Joining game: {selectedGame.Name}", "Join Game", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Please select a game to join.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (GameList.SelectedItem is Game selectedGame)
        {
            Games.Remove(selectedGame);
            MessageBox.Show($"Game '{selectedGame.Name}' has been deleted.", "Delete Game", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Please select a game to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}

public class Game
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    public override string ToString()
    {
        return $"{Name} (Created: {CreatedAt})";
    }
}
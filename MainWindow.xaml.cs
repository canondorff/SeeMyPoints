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

namespace SeeMyPoints;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new Dashboard());
    }
    private void NavigateToPage1(object sender, RoutedEventArgs e) { MainFrame.NavigationService.Navigate(new Dashboard()); }
    private void NavigateToPage2(object sender, RoutedEventArgs e) { MainFrame.NavigationService.Navigate(new Journees()); }
    private void NavigateToPage3(object sender, RoutedEventArgs e) { MainFrame.NavigationService.Navigate(new Epreuves()); }
    private void NavigateToPage4(object sender, RoutedEventArgs e) { MainFrame.NavigationService.Navigate(new Eleves()); }
    private void NavigateToPage5(object sender, RoutedEventArgs e) { MainFrame.NavigationService.Navigate(new Equipes()); }
    private void NavigateToPage6(object sender, RoutedEventArgs e) { MainFrame.NavigationService.Navigate(new Resultat()); }
    private void NavigateToPage7(object sender, RoutedEventArgs e) { MainFrame.NavigationService.Navigate(new Leaderboard()); }
}
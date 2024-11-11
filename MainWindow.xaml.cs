using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SeeMyPoints;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private bool _isDashboardSelected;
    private bool _isJourneesSelected;
    private bool _isEpreuvesSelected;
    private bool _isEquipesSelected;
    private bool _isLeaderboardSelected;
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        MainFrame.Navigate(new Dashboard());
        IsDashboardSelected = true;
    }
    
    // Etat btn navigation
    public bool IsDashboardSelected
    {
        get => _isDashboardSelected;
        set
        {
            _isDashboardSelected = value;
            OnPropertyChanged();
        }
    }
    public bool IsJourneesSelected
    {
        get => _isJourneesSelected;
        set
        {
            _isJourneesSelected = value;
            OnPropertyChanged();
        }
    }
    public bool IsEpreuvesSelected
    {
        get => _isEpreuvesSelected;
        set
        {
            _isEpreuvesSelected = value;
            OnPropertyChanged();
        }
    }
    public bool IsEquipesSelected
    {
        get => _isEquipesSelected;
        set
        {
            _isEquipesSelected = value;
            OnPropertyChanged();
        }
    }
    public bool IsLeaderboardSelected
    {
        get => _isLeaderboardSelected;
        set
        {
            _isLeaderboardSelected = value;
            OnPropertyChanged();
        }
    }
    
    // Navigation
    private void NavigateToPage1(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new Dashboard());
        SetSelectedPage("Dashboard");
    }

    private void NavigateToPage2(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new Journees());
        SetSelectedPage("Journees");
    }

    private void NavigateToPage3(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new Epreuves());
        SetSelectedPage("Epreuves");
    }

    private void NavigateToPage4(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new Equipes());
        SetSelectedPage("Equipes");
    }

    private void NavigateToPage5(object sender, RoutedEventArgs e)
    {
        MainFrame.NavigationService.Navigate(new Leaderboard());
        SetSelectedPage("Leaderboard");
    }

    private void SetSelectedPage(string page)
    {
        IsDashboardSelected = page == "Dashboard";
        IsJourneesSelected = page == "Journees";
        IsEpreuvesSelected = page == "Epreuves";
        IsEquipesSelected = page == "Equipes";
        IsLeaderboardSelected = page == "Leaderboard";
    }
    
    // Barre fenetre
    private void MinimizeWindow(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void MaximizeWindow(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
        }
        else
        {
            WindowState = WindowState.Maximized;
        }
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
        Close();
    }
    
    private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }
    
    // INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
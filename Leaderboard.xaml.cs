using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SeeMyPoints;

public partial class Leaderboard : Page
{
    public Leaderboard()
    {
        InitializeComponent();
    }
    
    private void OpenPopup_Click(object sender, RoutedEventArgs e)
    {
        MyPopup.IsOpen = true;
    }

    private void ClosePopup_Click(object sender, RoutedEventArgs e)
    {
        MyPopup.IsOpen = false;
    }
}
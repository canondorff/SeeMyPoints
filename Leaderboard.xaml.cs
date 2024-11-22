using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.Win32;

namespace SeeMyPoints;

public partial class Leaderboard : Page
{
    public Leaderboard()
    {
        InitializeComponent();
    }
    
    private void Import_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            string filePath = openFileDialog.FileName;
        }
    }
    
    private void ImportCsvToDatabase(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(',');

                if (values.Length >= 2)
                {
                    Eleve eleve = new Eleve(values[0], values[1]);
                    ADOEleve.insertEleve(eleve);
                }
            }
        }
    }
}
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SeeMyPoints;

public partial class Equipes : Page
{
    public Equipes()
    {
        InitializeComponent();
        LoadEquipes();
        // Assigner la liste au contexte de données pour le DataGrid
        DataContext = this;
    }
    
    private void LoadEquipes()
    {
        // Appel de la méthode GetAllEleves pour récupérer la liste des élèves
        List<Equipe> equipes = ADOEquipe.GetAllEquipes();
      
        foreach (Equipe element in equipes) { Console.WriteLine(element); }
    
        // Liaison de la liste d'élèves à la source d'éléments du DataGrid
        equipeDataGrid.ItemsSource = equipes;
    }
    
    private void AjouterEquipe_Click(object sender, RoutedEventArgs e)
    {
        string nomEquipe = nomInput.Text;
        int nbEleve = Convert.ToInt32(nbEleveInput.Text);
        
        
        
        Equipe newEquipe = new Equipe(nomEquipe);
        
        ADOEquipe.insertEquipe(newEquipe);
        
        LoadEquipes();
    }
}
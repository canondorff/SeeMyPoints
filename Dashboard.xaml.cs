using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SeeMyPoints;

public partial class Dashboard : Page
{
    public Dashboard()
    {
        InitializeComponent();
        LoadEleves();
        LoadEquipes();
        LoadEpreuves();
        LoadJournees();
        // Assigner la liste au contexte de données pour le DataGrid
        DataContext = this;
    }

    private void LoadEleves()
    {
        // Appel de la méthode GetAllEleves pour récupérer la liste des élèves
        List<Eleve> eleves = ADOEleve.GetAllEleves();
    
        // Liaison de la liste d'élèves à la source d'éléments du DataGrid
        elevesDataGrid.ItemsSource = eleves;
    }
    
    private void LoadEquipes()
    {
        // Appel de la méthode GetAllEleves pour récupérer la liste des élèves
        List<Equipe> equipes = ADOEquipe.GetAllEquipes();
    
        // Liaison de la liste d'élèves à la source d'éléments du DataGrid
        equipeDataGrid.ItemsSource = equipes;
    }
    
    private void LoadEpreuves()
    {
        // Appel de la méthode GetAllEleves pour récupérer la liste des élèves
        List<Epreuve> epreuves = ADOEpreuve.getAllEpreuve();
    
        // Liaison de la liste d'élèves à la source d'éléments du DataGrid
        epreuvesDataGrid.ItemsSource = epreuves;
    }
    
    private void LoadJournees()
    {
        // Appel de la méthode GetAllEleves pour récupérer la liste des élèves
        List<Journee> journees = ADOJournee.getAllJournee();
    
        // Liaison de la liste d'élèves à la source d'éléments du DataGrid
        journeesDataGrid.ItemsSource = journees;
    }
}
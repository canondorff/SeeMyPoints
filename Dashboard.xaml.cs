using System.Collections.ObjectModel;
using System.Windows;
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
        //LoadJournees();
        // Assigner la liste au contexte de données pour le DataGrid
        DataContext = this;
    }

    private void LoadEleves()
    {
        // Appel de la méthode GetAllEleves pour récupérer la liste des élèves
        List<Eleve> eleves = ADOEleve.GetAllEleves();
        
        int nbEleve = eleves.Count;
        
        nbEleves.Text = nbEleve.ToString();
        nbElevesPopup.Text = nbEleve.ToString();
        
        // Liaison de la liste d'élèves à la source d'éléments du DataGrid
        elevesDataGrid.ItemsSource = eleves;
        elevesDataGridFull.ItemsSource = eleves;
    }
    
    private void LoadEquipes()
    {
        // Appel de la méthode GetAllEleves pour récupérer la liste des élèves
        List<Equipe> equipes = ADOEquipe.GetAllEquipes();
      
        foreach (Equipe element in equipes) { Console.WriteLine(element); }
    
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
    
    //private void LoadJournees()
    //{
        // Appel de la méthode GetAllEleves pour récupérer la liste des élèves
      //  List<Journee> journees = ADOJournee.getAllJournee();
    
        // Liaison de la liste d'élèves à la source d'éléments du DataGrid
        //journeesDataGrid.ItemsSource = journees;
    //}
    
    private void OpenPopupScore_Click(object sender, RoutedEventArgs e)
    {
        PopupScore.IsOpen = true;
    }
    private void ClosePopupScore_Click(object sender, RoutedEventArgs e)
    {
        PopupScore.IsOpen = false;
    }
    
    private void OpenPopupEleve_Click(object sender, RoutedEventArgs e)
    {
        PopupEleve.IsOpen = true;
    }
    private void ClosePopupEleve_Click(object sender, RoutedEventArgs e)
    {
        PopupEleve.IsOpen = false;
    }
    
    private void OpenPopupAddEleve_Click(object sender, RoutedEventArgs e)
    {
        PopupAddEleve.IsOpen = true;
    }
    private void ClosePopupAddEleve_Click(object sender, RoutedEventArgs e)
    {
        PopupAddEleve.IsOpen = false;
    }
    
    private void AjouterEleve_Click(object sender, RoutedEventArgs e)
    {
        string nom_eleve = prenomInput.Text;
        string classe = classeInput.Text;
        
        Eleve newEleve = new Eleve(nom_eleve, classe);
        
        ADOEleve.insertEleve(newEleve);
        
        LoadEleves();
        
        PopupAddEleve.IsOpen = false;
    }
}
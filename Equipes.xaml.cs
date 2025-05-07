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
        
        List<Eleve> eleves = ADOEleve.GetAllEleves();
        // Filtrer les élèves qui n'ont pas encore d'équipe
        var elevesDisponibles = eleves.Where(e => e.IdEquipe == 0).ToList();
        
        if (elevesDisponibles.Count < nbEleve)
        {
            MessageBox.Show("Il n'y a pas assez d'élèves disponibles pour former cette équipe.");
            return;
        }

        Equipe newEquipe = new Equipe(nomEquipe);
        int equipeId = ADOEquipe.insertEquipe(newEquipe);

        // Sélection aléatoire des élèves
        Random random = new Random();
        var elevesSelectionnes = new List<Eleve>();
        
        // S'assurer d'avoir exactement le nombre d'élèves demandé
        while (elevesSelectionnes.Count < nbEleve)
        {            
            var eleveAleatoire = elevesDisponibles[random.Next(elevesDisponibles.Count)];
            if (!elevesSelectionnes.Contains(eleveAleatoire))
            {
                elevesSelectionnes.Add(eleveAleatoire);
            }
        }

        // Ajout des élèves à l'équipe et mise à jour dans la base de données
        foreach (var eleve in elevesSelectionnes)
        {
            newEquipe.AjouterEleve(eleve);
            ADOEleve.updateEleve(eleve, eleve.Id);
        }
        
        LoadEquipes();
    }
}
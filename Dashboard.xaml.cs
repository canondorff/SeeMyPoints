using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SeeMyPoints;

public class EquipeListe
{
    public string NomEquipe { get; set; }
    public string Score { get; set; }

    public EquipeListe(string nomEquipe, string score)
    {
        NomEquipe = nomEquipe;
        Score = score;
    }
}

public partial class Dashboard : Page
{
    // Déclarez la liste sous forme d'ObservableCollection pour la mise à jour dynamique
    public ObservableCollection<EquipeListe> EquipesListes { get; set; }

    public Dashboard()
    {
        InitializeComponent();
        LoadEleves();
        // Remplissez la liste avec des données d'exemple
        EquipesListes = new ObservableCollection<EquipeListe>
        {
            new EquipeListe("Equipe 1", "15"),
            new EquipeListe("Equipe 2", "14"),
            new EquipeListe("Equipe 3", "-"),
        };

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

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = sender as ComboBox;
        EquipeListe selectedTeam = comboBox.SelectedItem as EquipeListe;

        // Si vous souhaitez afficher des informations supplémentaires sur l'équipe sélectionnée
        if (selectedTeam != null)
        {
            // Exemple : Affichage dans la console
            Console.WriteLine($"Equipe sélectionnée : {selectedTeam.NomEquipe}, Score : {selectedTeam.Score}");
        }
    }
}
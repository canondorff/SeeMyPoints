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
}
namespace SeeMyPoints;

public class Equipe
{
    string nomEquipe;
    private int score;
    private List<Eleve> eleves;
    Dictionary<Epreuve, int> epreuves;
    public int Id { get; set; }
    
    public Equipe(string nom)
    {
        nomEquipe = nom;
        score = 0;
        eleves = new List<Eleve>();
    }
    
    public string Nom
    {
        get => nomEquipe;
        set => nomEquipe = value;
    }
    
    public int Score
    {
        get => score;
        set => score = value;
    }
    
    public override string ToString() { return $"{Nom}: {Score}"; }

    public void AjouterEleve(Eleve eleve)
    {
        eleves.Add(eleve);
        eleve.IdEquipe = Id;
    }
}
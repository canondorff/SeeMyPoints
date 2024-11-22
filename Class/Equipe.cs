namespace SeeMyPoints;

public class Equipe
{
    string nomEquipe;
    private int score;
    private List<Eleves> eleves;
    Dictionary<Epreuve, int> epreuves;
    
    public Equipe(string nom)
    {
        nomEquipe = nom;
        score = 0;
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
}
namespace SeeMyPoints;

public class Equipe
{
    string nomEquipe;
    private int score;
    private List<Epreuve> Epreuves;
    
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
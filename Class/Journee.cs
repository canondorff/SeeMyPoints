namespace SeeMyPoints;

public class Journee
{
    string nomJournee;
    DateTime dateJournee;
    string lieuJournee;
    
    public Journee(string nom, DateTime date, string lieu)
    {
        nomJournee = nom;
        dateJournee = date;
        lieuJournee = lieu;
    }
    
    public string Nom
    {
        get => nomJournee;
        set => nomJournee = value;
    }
    
    public DateTime Date
    {
        get => dateJournee;
        set => dateJournee = value;
    }
    
    public string Lieu
    {
        get => lieuJournee;
        set => lieuJournee = value;
    }
}
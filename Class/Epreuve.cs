namespace SeeMyPoints;

public class Epreuve
{
    string nomEpreuve;
    string descriptionEpreuve;
    
    public Epreuve(string nom, string description)
    {
        nomEpreuve = nom;
        descriptionEpreuve = description;
    }

    public string Nom
    {
        get => nomEpreuve;
        set => nomEpreuve = value;
    }
    
    public string Description
    {
        get => descriptionEpreuve;
        set => descriptionEpreuve = value;
    }
}
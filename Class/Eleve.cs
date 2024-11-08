namespace SeeMyPoints;

public class Eleve
{
    string nomEleve;
    string classeEleve;
    
    public Eleve(string nom, string classe)
    {
        this.nomEleve = nom;
        this.classeEleve = classe;
    }

    public string Nom
    {
        get => nomEleve;
        set => nomEleve = value;
    }
    
    public string Classe
    {
        get => classeEleve; 
    }
}
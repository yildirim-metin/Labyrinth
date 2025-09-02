using LabyrinthLibrary.Commons.Exceptions;

namespace LabyrinthLibrary.Models;

public class Wall : ILabyrinthElement
{
    public char Symbol => '*';

    public ILabyrinthObject? Content 
    {
        get => null;
        set => throw new LabyrinthException("Un mur ne contient pas d'objet.");
    }

    public void Visit(Person person)
    {
        throw new LabyrinthException("Les personnages ne traversent pas les murs.");
    }
}
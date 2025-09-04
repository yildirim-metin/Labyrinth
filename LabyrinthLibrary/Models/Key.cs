namespace LabyrinthLibrary.Models;

public class Key : ILabyrinthObject
{
    public char Symbol => 'f';

    public void Visit(Person person)
    {
        person.Bag.Add(this);
    }

    public override string ToString()
    {
        return "Clé";
    }
}
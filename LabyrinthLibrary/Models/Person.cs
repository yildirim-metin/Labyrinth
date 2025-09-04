namespace LabyrinthLibrary.Models;

public class Person : ILabyrinthObject
{
    public char Symbol { get; set; }
    public LabyrinthPosition? Position { get; set; }

    public ICollection<ILabyrinthObject> Bag { get; set; }

    public Person()
    {
        Bag = [];
    }

    public Person(char symbol) : this()
    {
        Symbol = symbol;
    }

    public Person(LabyrinthPosition position) : this()
    {
        Position = position;
    }

    public void Visit(Person person)
    {
        throw new NotImplementedException();
    }
}

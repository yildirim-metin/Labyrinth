namespace LabyrinthLibrary.Models;

public class Person : ILabyrinthObject
{
    public char Symbol => 'O';
    public LabyrinthPosition? Position { get; set; }

    public ICollection<ILabyrinthObject> Bag { get; set; }

    public Person()
    {
        Bag = [];
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

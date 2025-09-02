namespace LabyrinthLibrary.Models;

public class Person : ILabyrinthObject
{
    public char Symbol => 'O';
    public LabyrinthPosition? Position { get; set; }

    public Person()
    {
    }

    public Person(LabyrinthPosition position)
    {
        Position = position;
    }

    public void Visit(Person person)
    {
        throw new NotImplementedException();
    }
}

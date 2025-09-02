namespace LabyrinthLibrary.Models;

public class Person : ILabyrinthObject
{
    public char Symbol => 'O';
    public LabyrinthPosition? Position { get; init; }

    public Person()
    {
    }

    public Person(LabyrinthPosition position)
    {
        Position = position;
    }
}

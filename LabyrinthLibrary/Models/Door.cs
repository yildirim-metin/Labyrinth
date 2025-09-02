namespace LabyrinthLibrary.Models;

public class Door : ILabyrinthElement
{
    public ILabyrinthObject? Content { get; set; }

    public char Symbol => '|';

    private readonly bool _isOpen;

    public void Visit(Person person)
    {
        if (!_isOpen)
        {
            throw new DoorIsClosedException();
        }
    }
}

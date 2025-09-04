namespace LabyrinthLibrary.Models;

public class Door : ILabyrinthElement
{
    public ILabyrinthObject? Content { get; set; }

    public char Symbol => _isOpen ? '_' : '|';

    private bool _isOpen = false;

    public void Visit(Person person)
    {
        if (_isOpen)
        {
            Content = person;
            return;
        }

        bool hasKey = person.Bag.Any(o => o.Symbol == 'f');
        _isOpen = hasKey;

        if (!_isOpen)
        {
            throw new DoorIsClosedException();
        }
        
        Content = person;
        person.Bag.Remove(person.Bag.Single(o => o.Symbol == 'f'));
    }
}

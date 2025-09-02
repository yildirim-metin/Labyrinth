using System.Collections;

namespace LabyrinthLibrary.Models;

public class LabyrinthModel : IEnumerable
{
    private readonly SortedDictionary<LabyrinthPosition, ILabyrinthElement> _elements;

    public string Name { get; init; }

    public Person? Person { get; private set; }

    public ILabyrinthElement this[LabyrinthPosition position]
    {
        get => _elements[position];
        set
        {
            if (value.Content is Person)
            {
                Person = new Person(position);
            }
            _elements[position] = value;
        }
    }

    public LabyrinthModel(string name)
    {
        Name = name;
        _elements = [];
    }

    public IEnumerator GetEnumerator()
    {
        return _elements.GetEnumerator();
    }

    public void Move(Person person, Direction direction)
    {
        if (person.Position == null)
        {
            throw new OutOfLabyrinthException();
        }

        LabyrinthPosition destination = person.Position[direction];
        if (!_elements.TryGetValue(destination, out ILabyrinthElement? element))
        {
            person.Position = null;
            throw new OutOfLabyrinthException();
        }

        _elements[person.Position] = new Room();
        element.Visit(person);
        person.Position = destination;
     }

    public override string ToString()
    {
        string elements = string.Empty;
        foreach (var item in _elements)
        {
            elements += $"\n\t> {item.Key}, Symbol: {item.Value.Symbol}";
        }

        return Name + (elements.Length > 0 ? $" {elements}" : "");
    }
}

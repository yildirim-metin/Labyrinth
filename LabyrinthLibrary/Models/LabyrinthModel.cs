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

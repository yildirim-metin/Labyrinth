using System.Collections;
using System.Data;

namespace LabyrinthLibrary.Models;

public class LabyrinthModel : IEnumerable
{
    private readonly SortedDictionary<LabyrinthPosition, ILabyrinthElement> _elements;

    public string Name { get; set; }

    public ILabyrinthElement this[LabyrinthPosition position]
    {
        get => _elements[position];
        set => _elements[position] = value;
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
        return Name;
    }
}

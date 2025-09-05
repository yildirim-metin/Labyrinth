using LabyrinthLibrary.Commons.Exceptions;
using System.Collections;

namespace LabyrinthLibrary.Models;

public class LabyrinthModel : IEnumerable
{
    private readonly SortedDictionary<LabyrinthPosition, ILabyrinthElement> _elements;
    private readonly Dictionary<char, Person> _personMap;

    public string Name { get; init; }
    public Person? Person { get; private set; }
    public List<char> PersonKeys { get; set; }
    public int ActifPersonIndex { get; private set; }

    public ILabyrinthElement this[LabyrinthPosition position]
    {
        get => _elements[position];
        set
        {
            if (value.Content is Person person)
            {
                person.Position = position;

                PersonKeys.Add(person.Symbol);
                _personMap[person.Symbol] = person;

                Person ??= person;
            }
            _elements[position] = value;
        }
    }

    public Person this[char key]
    {
        get => _personMap[key];
    }

    public LabyrinthModel(string name)
    {
        Name = name;
        _elements = [];
        _personMap = [];
        PersonKeys = [];
        ActifPersonIndex = 0;
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

        LabyrinthPosition originPosition = person.Position;
        LabyrinthPosition destination = person.Position[direction];
        if (!_elements.TryGetValue(destination, out ILabyrinthElement? element))
        {
            person.Position = null;
            _elements[originPosition].Content = null;
            PersonKeys.Remove(person.Symbol);
            throw new OutOfLabyrinthException();
        }

        element.Visit(person);
        _elements[originPosition].Content = null;
        person.Position = destination;
     }

    public void ActivatePerson()
    {
        ActifPersonIndex = ++ActifPersonIndex % PersonKeys.Count;
        char key = PersonKeys[ActifPersonIndex];
        Person = _personMap[key];
    }

    public void ActivatePerson(char symbol)
    {
        var map = _personMap.SingleOrDefault(p => p.Value.Symbol == char.ToUpper(symbol));
        if (map.Value == null) return;
        ActifPersonIndex = PersonKeys.IndexOf(map.Key);
        Person = map.Value;
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

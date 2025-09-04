using LabyrinthLibrary.Models;

namespace LabyrinthLibrary.Commons.Builders;

public class LabyrinthBuilder
{
    private readonly Dictionary<string, Create> _factories;
    private char _currentPersonChar;

    public LabyrinthModel this[string name]
    {
        get
        {
            LabyrinthModel model = new(name);

            LabyrinthFileReader reader = new("D:\\_DEV\\Projets\\.NET\\Labyrinth\\LabyrinthLibrary\\test.laby");
            foreach (var item in reader.ReadFile())
            {
                if (char.IsUpper(item.Value[0]))
                {
                    _currentPersonChar = item.Value[0];
                    model[item.Key] = _factories["O"].Invoke();
                }
                else
                {
                    model[item.Key] = _factories.TryGetValue(item.Value, out Create? value)
                        ? value.Invoke()
                        : _factories["."].Invoke();
                }
            }

            return model;
        }
    }

    public LabyrinthBuilder()
    {
        _factories = new()
        {
            { "*", () => new Wall() },
            { ".", () => new Room() },
            { "O", () => new Room(new Person(_currentPersonChar)) },
            { "|", () => new Door() },
            { "f", () => new Room(new Key()) },
        };
    }

    public delegate ILabyrinthElement Create();
}

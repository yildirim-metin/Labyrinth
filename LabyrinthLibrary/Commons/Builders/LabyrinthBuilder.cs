using LabyrinthLibrary.Models;

namespace LabyrinthLibrary.Commons.Builders;

public class LabyrinthBuilder
{
    private readonly Dictionary<string, Create> _factories;
    public LabyrinthModel this[string name]
    {
        get
        {
            LabyrinthModel model = new(name);

            LabyrinthFileReader reader = new("D:\\_DEV\\Projets\\.NET\\Labyrinth\\LabyrinthLibrary\\test.laby");
            foreach (var item in reader.ReadFile())
            {
                model[item.Key] = _factories.TryGetValue(item.Value, out Create? value)
                    ? value.Invoke()
                    : _factories["."].Invoke();
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
            { "O", () => new Room(new Person()) },
            { "|", () => new Door() },
        };
    }

    public delegate ILabyrinthElement Create();
}

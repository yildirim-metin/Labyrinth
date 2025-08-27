using LabyrinthLibrary.Models;

namespace LabyrinthLibrary.Commons.Builders;

public class LabyrinthBuilder
{
    public LabyrinthModel this[string name]
    {
        get => new(name);
    }
}

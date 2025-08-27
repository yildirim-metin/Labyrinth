using LabyrinthLibrary.Models;

namespace LabyrinthLibrary.Commons;

public class LabyrinthBuilder
{
    public LabyrinthModel this[string name]
    {
        get => new(name);
    }
}

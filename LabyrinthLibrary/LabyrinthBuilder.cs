namespace LabyrinthLibrary;

public class LabyrinthBuilder
{
    public LabyrinthModel this[string name]
    {
        get => new(name);
    }
}

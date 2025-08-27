namespace LabyrinthLibrary.Models;

public class LabyrinthModel(string name)
{
    public string Name { get; set; } = name;

    public override string ToString()
    {
        return Name;
    }
}

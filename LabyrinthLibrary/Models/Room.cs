namespace LabyrinthLibrary.Models;

public class Room : ILabyrinthElement
{
    public char Symbol => Content != null ? Content.Symbol : '.';

    public ILabyrinthObject? Content { get; set; }

    public Room()
    {
        Content = null;
    }

    public Room(ILabyrinthObject content)
    {
        Content = content;
    }
}

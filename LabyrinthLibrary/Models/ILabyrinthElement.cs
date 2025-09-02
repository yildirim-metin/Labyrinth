namespace LabyrinthLibrary.Models;

public interface ILabyrinthElement : ISymbol
{
    public ILabyrinthObject? Content { get; }
}

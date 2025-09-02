namespace LabyrinthLibrary.Models;

public interface ILabyrinthElement : ISymbol, IPersonVisitable
{
    public ILabyrinthObject? Content { get; set; }
}

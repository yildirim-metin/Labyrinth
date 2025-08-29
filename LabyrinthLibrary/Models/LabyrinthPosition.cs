namespace LabyrinthLibrary.Models;

public class LabyrinthPosition : IComparable
{
    public int Row { get; init; }
    public int Column { get; init; }

    public LabyrinthPosition(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override bool Equals(object? obj)
    {
        if (obj is LabyrinthPosition lp)
        {
            return Row == lp.Row && Column == lp.Column;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }

    public int CompareTo(object? obj)
    {
        if (obj is not LabyrinthPosition lp)
        {
            throw new ArgumentException($"Cannot convert type '{obj?.GetType()}' in type '{GetType()}'");
        }

        int result = Row.CompareTo(lp.Row);
        if (result == 0)
        {
            result = Column.CompareTo(lp.Column);
        }
        return result;
    }

    public override string ToString()
    {
        return $"Row: {Row}, Column: {Column}";
    }
}

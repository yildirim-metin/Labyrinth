using LabyrinthLibrary.Models;

namespace LabyrinthLibrary.Views;

public class LabyrinthView
{
    public void Display(LabyrinthModel model, string? message)
    {
        Console.Clear();

        int row = 0;
        int column = 0;

        foreach (var item in model)
        {
            if (item is KeyValuePair<LabyrinthPosition, ILabyrinthElement> element)
            {
                if (element.Key.Row > row)
                {
                    row++;
                    column = 0;
                    Console.WriteLine();
                }

                column = MoveToColumn(column, element.Key);

                Console.Write(element.Value.Symbol);
                column++;
            }
        }

        if (!string.IsNullOrEmpty(message))
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    private static int MoveToColumn(int currentColumn, LabyrinthPosition position)
    {
        while (currentColumn / 2 < position.Column)
        {
            Console.Write(" ");
            currentColumn++;
        }

        return currentColumn;
    }
}

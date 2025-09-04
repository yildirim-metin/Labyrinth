using LabyrinthLibrary.Models;

namespace LabyrinthLibrary.Views;

public class LabyrinthView
{
    public void Display(LabyrinthModel model, string? message)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();

        DisplayLabyrinth(model);

        DisplayMessageIsNotEmpty(message);

        DisplayInventory(model);
    }

    private static void DisplayInventory(LabyrinthModel model)
    {
        if (model.Person == null)
        {
            return;
        }

        Console.WriteLine();
        Console.WriteLine("======================");
        Console.WriteLine("===== INVENTAIRE =====");
        Console.WriteLine("======================");

        if (model.Person.Bag.Count == 0)
        {
            Console.WriteLine("L'inventaire est vide.");
        }

        foreach (var o in model.Person.Bag)
        {
            Console.WriteLine(o);
        }
    }

    private static void DisplayMessageIsNotEmpty(string? message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    private static void DisplayLabyrinth(LabyrinthModel model)
    {
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

                Console.Write(element.Value.Symbol == '_' && element.Value.Content != null ? "O\u0332" : element.Value.Symbol);
                column++;
            }
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

    public void DisplayEndGame(LabyrinthModel model)
    {
        string endGame = "Partie terminée: ";
        Console.WriteLine(model.Person!.Position == null
            ? $"{endGame}Bravo !"
            : $"{endGame}Dommage...");
    }
}

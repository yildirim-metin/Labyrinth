using LabyrinthLibrary.Models;
using LabyrinthLibrary.Views;

namespace LabyrinthLibrary.Controllers;

public class LabyrinthController
{
    public LabyrinthModel Model { get; init; }
    public LabyrinthView View { get; init; }

    public LabyrinthController(LabyrinthModel model, LabyrinthView view)
    {
        Model = model;
        View = view;
    }

    public void Start()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            View.Display(Model, "View test.laby");
            
            ConsoleKeyInfo infoKey = Console.ReadKey(true);
            if (IsPlayerExitedGame(infoKey))
            {
                exit = true;
            }
            else
            {
                Direction? direction = GetKeyDirection(infoKey);
                if (direction != null)
                {
                    try
                    {
                        Model.Move(Model.Person!, (Direction)direction);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }

    private static bool IsPlayerExitedGame(ConsoleKeyInfo infoKey)
    {
        bool pressedQ = infoKey.Key == ConsoleKey.Q;
        bool pressedControl = (infoKey.Modifiers & ConsoleModifiers.Control) != 0;
        bool pressedShift = (infoKey.Modifiers & ConsoleModifiers.Shift) != 0;
        return pressedQ && pressedControl && pressedShift;
    }

    private static Direction? GetKeyDirection(ConsoleKeyInfo infoKey)
    {
        return infoKey.Key switch
        {
            ConsoleKey.UpArrow => Direction.North,
            ConsoleKey.DownArrow => Direction.South,
            ConsoleKey.LeftArrow => Direction.East,
            ConsoleKey.RightArrow => Direction.West,
            _ => null,
        };
    }
}

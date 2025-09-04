using LabyrinthLibrary.Commons.Exceptions;
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
        string message = string.Empty;

        while (!exit && !IsGameFinished())
        {
            View.Display(Model, message);
            
            ConsoleKeyInfo infoKey = Console.ReadKey(true);
            if (IsPlayerExitedGame(infoKey))
            {
                exit = true;
            }
            else if (infoKey.Key == ConsoleKey.Tab)
            {
                Model.ActivatePerson();
            }
            else if (char.IsLetter(infoKey.KeyChar))
            {
                Model.ActivatePerson(infoKey.KeyChar);
            }
            else
            {
                Direction? direction = GetKeyDirection(infoKey);
                if (direction != null)
                {
                    try
                    {
                        Model.Move(Model.Person!, (Direction)direction);
                        message = string.Empty;
                    }
                    catch (LabyrinthException ex)
                    {
                        message = ex.Message;
                    }
                }
            }
        }

        View.DisplayEndGame(Model);
    }

    private static bool IsPlayerExitedGame(ConsoleKeyInfo infoKey)
    {
        bool pressedQ = infoKey.Key == ConsoleKey.Q;
        bool pressedControl = (infoKey.Modifiers & ConsoleModifiers.Control) != 0;
        bool pressedShift = (infoKey.Modifiers & ConsoleModifiers.Shift) != 0;
        return pressedQ && pressedControl && pressedShift;
    }

    private bool IsGameFinished()
    {
        return Model.Person != null && Model.Person.Position == null;
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

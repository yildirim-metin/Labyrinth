using LabyrinthLibrary.Models;

namespace LabyrinthLibrary.Views;

public class LabyrinthView
{
    public void Display(LabyrinthModel model, string message)
    {
        Console.WriteLine(message + $" model: {model}");
    }
}

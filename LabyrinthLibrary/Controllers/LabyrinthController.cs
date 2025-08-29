using LabyrinthLibrary.Commons;
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
        View.Display(Model, "Start :");

        LabyrinthFileReader reader = new("D:\\_DEV\\Projets\\.NET\\Labyrinth\\LabyrinthLibrary\\test.laby");
        reader.ReadFile();

        LabyrinthPosition labyrinthPosition = new(1, 2);
        Console.WriteLine(labyrinthPosition.CompareTo(new LabyrinthPosition(0, 3)));
    }
}

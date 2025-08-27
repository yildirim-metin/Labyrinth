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

        LabyrinthFileReader reader = new("E:\\_DEV\\Projets\\.NET\\Labyrinth\\LabyrinthLibrary\\test.laby");
        reader.ReadFile();
    }
}

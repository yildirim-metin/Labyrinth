namespace LabyrinthLibrary;

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
    }
}

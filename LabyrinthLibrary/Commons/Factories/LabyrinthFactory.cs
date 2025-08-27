using LabyrinthLibrary.Controllers;
using LabyrinthLibrary.Models;
using LabyrinthLibrary.Views;

namespace LabyrinthLibrary.Commons.Factories;

public class LabyrinthFactory : ILabyrinthFactory
{
    public LabyrinthController CreateController()
    {
        return new LabyrinthController(CreateModel(), CreateView());
    }

    private LabyrinthModel CreateModel()
    {
        LabyrinthBuilder builder = new();
        return builder["Test"];
    }

    private LabyrinthView CreateView()
    {
        return new();
    }
}

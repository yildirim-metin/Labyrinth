using LabyrinthLibrary.Controllers;

namespace LabyrinthLibrary.Commons.Factories;

public interface ILabyrinthFactory
{
    public LabyrinthController CreateController();
}
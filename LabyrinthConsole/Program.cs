using LabyrinthLibrary.Commons;
using LabyrinthLibrary.Controllers;
using LabyrinthLibrary.Views;

Console.WriteLine("Hello Labyrinth");

LabyrinthBuilder builder = new();
LabyrinthView view = new();
LabyrinthController controller = new(builder["Test"], view);
controller.Start();
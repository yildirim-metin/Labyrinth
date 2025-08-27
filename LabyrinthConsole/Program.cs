using LabyrinthLibrary.Commons.Factories;

Console.WriteLine("Hello Labyrinth");

LabyrinthFactory factory = new();
factory.CreateController().Start();
using LabyrinthLibrary.Commons.Exceptions;

namespace LabyrinthLibrary.Models;

public class DoorIsClosedException : LabyrinthException
{
    public DoorIsClosedException() : base("La porte est fermée.")
    {
    }
}
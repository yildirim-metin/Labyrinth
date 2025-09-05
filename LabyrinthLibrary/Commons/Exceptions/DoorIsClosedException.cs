namespace LabyrinthLibrary.Commons.Exceptions;

public class DoorIsClosedException : LabyrinthException
{
    public DoorIsClosedException() : base("La porte est fermée.")
    {
    }
}
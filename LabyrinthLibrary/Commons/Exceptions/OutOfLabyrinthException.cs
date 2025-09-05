namespace LabyrinthLibrary.Commons.Exceptions;

public class OutOfLabyrinthException : LabyrinthException
{
    public OutOfLabyrinthException() : base("Le personnage est sortit du labyrinthe.")
    {
    }
}
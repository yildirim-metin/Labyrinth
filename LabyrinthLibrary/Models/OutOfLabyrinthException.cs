
using LabyrinthLibrary.Commons.Exceptions;

namespace LabyrinthLibrary.Models;

public class OutOfLabyrinthException : LabyrinthException
{
    public OutOfLabyrinthException() : base("Le personnage est sortit du labyrinthe.")
    {
    }
}
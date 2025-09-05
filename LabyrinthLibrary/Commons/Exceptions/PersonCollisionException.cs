namespace LabyrinthLibrary.Commons.Exceptions;

public class PersonCollisionException : LabyrinthException
{
    public PersonCollisionException() : base("Collision de personnage.")
    {
        
    }

    public PersonCollisionException(string message) : base(message)
    {
        
    }
}
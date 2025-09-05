using LabyrinthLibrary.Commons.Exceptions;

namespace LabyrinthLibrary.Models;

public class Person : ILabyrinthObject
{
    public char Symbol { get; set; }
    public LabyrinthPosition? Position { get; set; }

    public ICollection<ILabyrinthObject> Bag { get; set; }

    public Person()
    {
        Bag = [];
    }

    public Person(char symbol) : this()
    {
        Symbol = symbol;
    }

    public Person(LabyrinthPosition position) : this()
    {
        Position = position;
    }

    public void Visit(Person person)
    {
        if (person.Bag.Count > 0)
        {
            foreach (var item in person.Bag)
            {
                Bag.Add(item);
            }
            person.Bag.Clear();
         
            throw new PersonCollisionException(
                $"Personnage {person.Symbol} a donné ces affaires au personnage {Symbol}");
        }
        else
        {
            throw new PersonCollisionException(
                $"Personnage {person.Symbol} est bloqué par le personnage {Symbol}");
        }
    }
}

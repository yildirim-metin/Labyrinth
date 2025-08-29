using LabyrinthLibrary.Models;

namespace LabyrinthLibrary.Commons;

public class LabyrinthFileReader
{
    public string Path { get; set; }

    public LabyrinthFileReader(string path)
    {
        Path = path;
    }

    public IEnumerable<KeyValuePair<LabyrinthPosition, string>> ReadFile()
    {
        StreamReader sr = new(Path);

        int row = 0;
        int column;

        string? line = sr.ReadLine();
        while (!sr.EndOfStream || line != null)
        {
            column = 0;
            foreach (var c in line!)
            {
                if (c != ' ')
                {
                    yield return KeyValuePair.Create(
                        new LabyrinthPosition(row, column),
                        char.ToString(c));
                }
                column++;
            }
            
            line = sr.ReadLine();
            row++;
        }
    }
}

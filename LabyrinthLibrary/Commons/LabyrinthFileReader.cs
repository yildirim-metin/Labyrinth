namespace LabyrinthLibrary.Commons;

public class LabyrinthFileReader
{
    public string Path { get; set; }

    public LabyrinthFileReader(string path)
    {
        Path = path;
    }

    public void ReadFile()
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
                    Console.WriteLine($"char: {c}, ligne: {row}, colonne: {column}");
                }
                column++;
            }
            
            line = sr.ReadLine();
            row++;
        }
    }
}

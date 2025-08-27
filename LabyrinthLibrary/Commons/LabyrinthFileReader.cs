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

        string s = string.Empty;
        while (!sr.EndOfStream)
        {
            int c = sr.Read();
            s += (char)c;
        }
        Console.WriteLine(s);
    }
}

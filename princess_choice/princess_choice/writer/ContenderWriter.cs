namespace princess_choice.writer;

public class ContenderWriter : IWriter
{
    /// <summary>
    /// File name, which you want to write in.
    /// </summary>
    private string _fileName = "test.txt";

    public ContenderWriter()
    {
        File.Delete(_fileName);
    }
    
    /// <summary>
    /// Write content in file.
    /// </summary>
    /// <param name="content">Content you want write in file.</param>
    public void Write(string content)
    {
        using var output = new StreamWriter(_fileName, true);
        output.WriteLine(content);
    }
}
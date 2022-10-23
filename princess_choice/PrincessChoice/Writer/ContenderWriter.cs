using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PrincessChoice.Writer;

public class ContenderWriter : IWriter
{
    /// <summary>
    /// File name, set up in appsettings.json.
    /// </summary>
    private readonly string? _fileName;

    public ContenderWriter(IConfiguration config)
    {
        _fileName = config.GetValue<string>("Writer:Name");
    }
    
    /// <summary>
    /// Write content in file.
    /// </summary>
    /// <param name="content">Content you want write in file.</param>
    public void Write(string content)
    {
        using var output = new StreamWriter(_fileName ?? throw new NullReferenceException(), true);
        output.WriteLine(content);
    }

    /// <summary>
    /// Delete file.
    /// </summary>
    public void Delete()
    {
        File.Delete(_fileName ?? throw new NullReferenceException());
    }
}
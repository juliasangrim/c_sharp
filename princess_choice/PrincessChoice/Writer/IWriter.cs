namespace PrincessChoice.Writer;

public interface IWriter
{
    /// <summary>
    /// Write content.
    /// </summary>
    /// <param name="content">Content you want write.</param>
    void Write(string content);

    /// <summary>
    /// Delete file with name, set up in appsettings.json.
    /// </summary>
    void Delete();
}
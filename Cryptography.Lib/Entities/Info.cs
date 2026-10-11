using System.Text;

namespace Cryptography.Lib.Entities;

public sealed class Info(string title)
{
    public string Title { get; } = title;
    private readonly StringBuilder contentBuilder = new();
    private const int Width = 25;

    public void AddContent(string text)
    {
        contentBuilder.AppendLine(text);
    }

    public void AddBounds()
    {
        contentBuilder.AppendLine(new string('-', Width));
    }

    public void AddContentWithUpperBounds(string text)
    {
        AddBounds();
        AddContent(text);
    }

    public void AddContentWithLowerBounds(string text)
    {
        AddContent(text);
        AddBounds();
    }

    public void AddContentWithBounds(string text)
    {
        AddBounds();
        AddContent(text);
        AddBounds();
    }

    public override string ToString()
    {
        var sBuilder = new StringBuilder();

        //header
        sBuilder.AppendLine($"--{Title}{new string('-', Width - 2 - Title.Length)}");
        //content
        sBuilder.Append(contentBuilder);

        return sBuilder.ToString();
    }

    internal void AddContent(object crypterName)
    {
        throw new NotImplementedException();
    }
}
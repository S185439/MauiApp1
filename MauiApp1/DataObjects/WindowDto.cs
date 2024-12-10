namespace MauiApp1.DataObjects;

public class WindowDto
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public required string PageName { get; set; }

    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Title))
            return PageName;
        return Title;
    }
}

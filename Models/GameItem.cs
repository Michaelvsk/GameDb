namespace Models;

public class GameItem : BaseItem
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid Cover { get; set; } = Guid.Empty;

    public HashSet<Platform> Platform { get; set; } = new HashSet<Platform>();
    
    public HashSet<Genre> Genre { get; set; } = new HashSet<Genre>();

    public Rating Rating { get; set; } = Rating.NotRated;
}

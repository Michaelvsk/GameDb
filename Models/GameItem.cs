namespace Models;

internal class GameItem : BaseItem
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public Guid Cover { get; set; }

    public HashSet<Platform> Platform { get; set; } = new HashSet<Platform>();
    
    public HashSet<Genre> Genre { get; set; } = new HashSet<Genre>();
}

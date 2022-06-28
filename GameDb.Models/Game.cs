using CommunityToolkit.Diagnostics;

namespace Michaelvsk.GameDb.Models;

// TODO Add OwnerId to distinguish items by user
public class Game : BaseItem
{
    string _title;
    public string Title
    {
        get => _title;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            _title = value;
        }
    }

    public string? Description { get; set; }

    Guid _coverId;
    public Guid CoverId
    {
        get => _coverId;
        set
        {
            Guard.IsNotDefault<Guid>(value);
            _coverId = value;
        }
    }

    public HashSet<Platform> Platform { get; set; } = new HashSet<Platform>();
    
    public HashSet<Genre> Genre { get; set; } = new HashSet<Genre>();

    public Rating Rating { get; set; } = Rating.NotRated;

    // Disable warning as analyzer does not recognise that _title is not null if constructor succeeds.
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Game(string title)
    {
        Title = title;
        Id = Guid.NewGuid();
    }
    #pragma warning restore CS8618
}

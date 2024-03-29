﻿using CommunityToolkit.Diagnostics;

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

    Guid? _coverId;
    public Guid? CoverId
    {
        get => _coverId;
        set
        {
            Guard.IsNotNull(value);
            Guard.IsNotDefault((Guid)value);
            _coverId = value;
        }
    }

    public HashSet<Platform> Platform { get; set; } = new HashSet<Platform>();
    
    public HashSet<Genre> Genre { get; set; } = new HashSet<Genre>();

    public Rating Rating { get; set; } = Rating.NotRated;

    #pragma warning disable CS8618 // Disable Non-nullable field warning as analyzer does not recognize that _title is not null if constructor succeeds.
    public Game(string title)
    {
        Title = title;
        Id = Guid.NewGuid();
    }

    public Game(Guid id, string title)
    {
        Title = title;
        Id = id;
    }
    #pragma warning restore CS8618
}

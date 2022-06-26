using CommunityToolkit.Diagnostics;

namespace Michaelvsk.GameDb.Models;

public class BaseItem
{
    private Guid _id;
    public Guid Id
    {
        get => _id;
        
        set
        {
            Guard.IsNotDefault<Guid>(value);
            _id = value;
        }
    }
}

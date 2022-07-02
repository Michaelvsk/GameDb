using CommunityToolkit.Diagnostics;

namespace Michaelvsk.GameDb.Models;

public abstract class BaseItem
{
    private Guid _id;
    public Guid Id
    {
        get => _id;
        
        protected set
        {
            Guard.IsNotDefault<Guid>(value);
            _id = value;
        }
    }
}

using CommunityToolkit.Diagnostics;

namespace Michaelvsk.GameDb.Models;
public class Cover : BaseItem
{
    byte[] _pngData;
    public byte[] PngData
    {
        get => _pngData;
        
        set
        {
            Guard.IsNotNull(value);
            Guard.IsGreaterThan(value.Length, 0);

            _pngData = value;
        }
    }

    // Constructor indeed ensures that _pngData is properly initialized. Check are in PngData's setter.
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Cover(byte[] pngData)
    {
        Id = Guid.NewGuid();
        PngData = pngData;
    }

    public Cover(Guid id, byte[] pngData)
    {
        Id = id;
        PngData = pngData;
    }
    #pragma warning restore CS8618
}

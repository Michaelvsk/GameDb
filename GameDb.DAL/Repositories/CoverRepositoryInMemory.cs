using System.Diagnostics.CodeAnalysis;

using CommunityToolkit.Diagnostics;

using Michaelvsk.GameDb.Common.Errors;
using Michaelvsk.GameDb.Models;

using OneOf;

namespace Michaelvsk.GameDb.DAL.Repositories;

[ExcludeFromCodeCoverage]
public class CoverRepositoryInMemory : ICoverRepository
{
    readonly List<Cover> _covers = new()
    {
        // FIXME Paths only work for windows build and not for Tests
        new Cover(new Guid("11111111-1111-1111-1111-111111111112"),
            File.ReadAllBytes(Path.Combine(
#pragma warning disable CS8604 // Possible null reference argument.
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
#pragma warning restore CS8604 // Possible null reference argument.
                ,".."
                , "11111111-1111-1111-1111-111111111112.png"))
            )
        ,
        new Cover(new Guid("21111111-1111-1111-1111-111111111112"),
            File.ReadAllBytes(Path.Combine(
#pragma warning disable CS8604 // Possible null reference argument.
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
#pragma warning restore CS8604 // Possible null reference argument.
                ,".."
                , "21111111-1111-1111-1111-111111111112.png"))
            ),
    };

    public async Task<OneOf<Cover, NotFound>> GetCoverByIdAsync(Guid id)
    {
        Guard.IsNotDefault(id);

        var cover = await Task.Run(() => _covers.FirstOrDefault(c => c.Id == id));

        if (cover != null) return cover;

        return new NotFound("Cover with specified Id not found.");
    }
}

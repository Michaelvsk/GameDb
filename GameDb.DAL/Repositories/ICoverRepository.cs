using Michaelvsk.GameDb.Common.Errors;
using Michaelvsk.GameDb.Models;

using OneOf;

namespace Michaelvsk.GameDb.DAL.Repositories;
public interface ICoverRepository
{
    Task<OneOf<Cover, NotFound>> GetCoverByIdAsync(Guid id);
}

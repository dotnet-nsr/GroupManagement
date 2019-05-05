using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using dotnetNsr.PlayBall.GroupManagement.Business.Models;

namespace dotnetNsr.PlayBall.GroupManagement.Business.Services
{
    public interface IGroupsService
    {
        Task<IReadOnlyCollection<Group>> GetAll(CancellationToken cancellationToken);

        Task<Group> GetById(long id, CancellationToken cancellationToken);

        Task<Group> Update(Group group, CancellationToken cancellationToken);

        Task<Group> Add(Group group, CancellationToken cancellationToken);
    }
}
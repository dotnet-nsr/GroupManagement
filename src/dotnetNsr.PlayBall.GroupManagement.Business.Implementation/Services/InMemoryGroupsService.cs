using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dotnetNsr.PlayBall.GroupManagement.Business.Models;
using dotnetNsr.PlayBall.GroupManagement.Business.Services;

namespace dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Services
{
    public class InMemoryGroupsService : IGroupsService
    {
        private readonly List<Group> _groups = new List<Group>();
        private int _currentId = 0;
        
        public Task<IReadOnlyCollection<Group>> GetAll(CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyCollection<Group>>(_groups.AsReadOnly());
        }

        public Task<Group> GetById(long id, CancellationToken cancellationToken)
        {
            return Task.FromResult(_groups.SingleOrDefault(g => g.Id == id));
        }

        public Task<Group> Update(Group group, CancellationToken cancellationToken)
        {
            var toUpdate =  _groups.SingleOrDefault(g => g.Id == group.Id);

            if (toUpdate == null)
            {
                return null;
            }

            toUpdate.Name = group.Name;
            return Task.FromResult(toUpdate);
        }

        public Task<Group> Add(Group group, CancellationToken cancellationToken)
        {
            group.Id = ++_currentId;
            _groups.Add(group);

            return Task.FromResult(group);
        }
    }
}
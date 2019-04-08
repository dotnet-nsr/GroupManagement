using System.Collections.Generic;
using System.Linq;
using dotnetNsr.PlayBall.GroupManagement.Business.Models;
using dotnetNsr.PlayBall.GroupManagement.Business.Services;

namespace dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Services
{
    public class InMemoryGroupsService : IGroupsService
    {
        private readonly List<Group> _groups = new List<Group>();
        private int currentId = 0;
        
        public IReadOnlyCollection<Group> GetAll()
        {
            return _groups.AsReadOnly();
        }

        public Group GetById(long id)
        {
            return _groups.SingleOrDefault(g => g.Id == id);
        }

        public Group Update(Group group)
        {
            var toUpdate = _groups.SingleOrDefault(g => g.Id == group.Id);

            if (toUpdate == null)
            {
                return null;
            }

            toUpdate.Name = group.Name;
            return toUpdate;
        }

        public Group Add(Group group)
        {
            group.Id = ++currentId;
            _groups.Add(group);

            return group;
        }
    }
}
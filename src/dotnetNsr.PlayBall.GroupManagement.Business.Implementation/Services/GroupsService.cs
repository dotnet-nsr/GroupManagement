using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Mappings;
using dotnetNsr.PlayBall.GroupManagement.Business.Models;
using dotnetNsr.PlayBall.GroupManagement.Business.Services;
using dotnetNsr.PlayBall.GroupManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly GroupManagementDbContext _context;

        public GroupsService(GroupManagementDbContext context)
        {
            _context = context;
        }
        
        public async Task<IReadOnlyCollection<Group>> GetAll(CancellationToken cancellationToken)
        {
            var groups = await _context.Groups.ToListAsync(cancellationToken);
            return groups.ToService();
        }

        public async Task<Group> GetById(long id, CancellationToken cancellationToken)
        {
            var groups = await _context.Groups.SingleOrDefaultAsync(g => g.Id == id, cancellationToken);
            return groups.ToService();
        }

        public async Task<Group> Update(Group group, CancellationToken cancellationToken)
        {
            var updatedGroupEntity =  _context.Groups.Update(group.ToEntity());
            await _context.SaveChangesAsync(cancellationToken);
            return updatedGroupEntity.Entity.ToService();
        }

        public async Task<Group> Add(Group group, CancellationToken cancellationToken)
        {
            var addedGroupEntry = _context.Groups.Add(group.ToEntity());
            await _context.SaveChangesAsync(cancellationToken);
            return addedGroupEntry.Entity.ToService();
        }
    }
}
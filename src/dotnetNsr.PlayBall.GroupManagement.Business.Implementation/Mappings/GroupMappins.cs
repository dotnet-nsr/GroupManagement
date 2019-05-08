using System.Collections.Generic;
using dotnetNsr.PlayBall.GroupManagement.Business.Models;
using dotnetNsr.PlayBall.GroupManagement.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Mappings
{
    internal static class GroupMappins
    {
        public static Group ToService(this GroupEntity entity)
        {
            return entity != null ? new Group {Id = entity.Id, Name = entity.Name} : null;
        }
            
        public static GroupEntity ToEntity(this Group model)
        {
            return model != null ? new GroupEntity {Id = model.Id, Name = model.Name} : null;
        }

        public static IReadOnlyCollection<Group> ToService(this IReadOnlyCollection<GroupEntity> entities)
        {
            return entities.MapCollection(ToService);
        }
    }
}
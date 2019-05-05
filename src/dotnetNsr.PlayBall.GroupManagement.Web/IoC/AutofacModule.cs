using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Services;
using dotnetNsr.PlayBall.GroupManagement.Business.Models;
using dotnetNsr.PlayBall.GroupManagement.Business.Services;
using Microsoft.Extensions.Logging;

namespace dotnetNsr.PlayBall.GroupManagement.Web.IoC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryGroupsService>().Named<IGroupsService>("groupService").SingleInstance();
            builder.RegisterDecorator<IGroupsService>((context, service) => new GroupServiceDecorator(service, context.Resolve<ILogger<GroupServiceDecorator>>()), "groupService");
        }

        private class GroupServiceDecorator : IGroupsService
        {
            private readonly IGroupsService _inner;
            private readonly ILogger<GroupServiceDecorator> _logger;

            public GroupServiceDecorator(IGroupsService inner, ILogger<GroupServiceDecorator> logger)
            {
                _inner = inner;
                _logger = logger;
            }
            
            public Task<IReadOnlyCollection<Group>> GetAll(CancellationToken cancellationToken)
            {
                _logger.LogWarning($"Hellö from {nameof(GetAll)}");
                
                return _inner.GetAll(cancellationToken);
            }

            public Task<Group> GetById(long id, CancellationToken cancellationToken)
            {
                _logger.LogWarning($"Hellö from {nameof(GetAll)}");

                return _inner.GetById(id, cancellationToken);
            }

            public Task<Group> Update(Group group, CancellationToken cancellationToken)
            {
                _logger.LogWarning($"Hellö from {nameof(GetAll)}");
                
                return _inner.Update(group,cancellationToken);
            }

            public Task<Group> Add(Group group, CancellationToken cancellationToken)
            {
                _logger.LogWarning($"Hellö from {nameof(GetAll)}");
                
                 return _inner.Add(group, cancellationToken);
            }
        }
    }
}
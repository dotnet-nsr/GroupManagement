using dotnetNsr.PlayBall.GroupManagement.Data.Configurations;
using dotnetNsr.PlayBall.GroupManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnetNsr.PlayBall.GroupManagement.Data
{
    public class GroupManagementDbContext : DbContext
    {
        public DbSet<GroupEntity> Groups { get; set; }

        public GroupManagementDbContext(DbContextOptions<GroupManagementDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new GroupEntityConfiguration());
        }
    }
}
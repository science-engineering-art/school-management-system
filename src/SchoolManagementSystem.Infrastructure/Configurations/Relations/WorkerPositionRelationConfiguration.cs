using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Infrastructure.Configurations.Relations;

public class WorkerPositionRelationConfiguration : IEntityTypeConfiguration<WorkerPositionRelation>
{
    public void Configure(EntityTypeBuilder<WorkerPositionRelation> builder)
    {
        throw new NotImplementedException();
    }
}
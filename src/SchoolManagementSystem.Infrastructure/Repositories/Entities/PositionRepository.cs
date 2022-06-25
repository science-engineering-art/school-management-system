using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Persistence;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class PositionRepository : CrudRepository<Position>, IPositionRepository
{
    public PositionRepository(IObjectContext context) : base(context)
    {

    }
}
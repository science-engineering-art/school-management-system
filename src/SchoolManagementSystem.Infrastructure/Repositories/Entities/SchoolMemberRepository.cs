using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class SchoolMemberRepository : ActiveRepository<SchoolMember>, ISchoolMemberRepository
{
    public SchoolMemberRepository(IObjectContext context) : base(context)
    {

    }
}
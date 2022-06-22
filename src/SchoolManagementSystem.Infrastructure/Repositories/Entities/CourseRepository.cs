using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;

namespace SchoolManagementSystem.Infrastructure.Repositories.Entities;

public class CourseRepository : CrudRepository<Course>, ICourseRepository
{
    public CourseRepository(IObjectContext context) : base(context)
    {

    }
}
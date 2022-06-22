
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services.Entities;

namespace SchoolManagementSystem.Application.Services_Implementations.Entities;

public class TeacherService : BaseService<Teacher>, ITeacherService
{
    public TeacherService(ITeacherRepository repository) : base(repository)
    {

    }

    public Teacher GetTeacherById(string id)
    {
        return Query()
            .Where(teacher => teacher.Id == id)
            .Include(teacher => teacher.Services)
            .Include(teacher => teacher.AdditionalServices)
            .Include(teacher => teacher.CourseGroups)
            .Include(teacher => teacher.TeacherCourseRelations)
            .Include(teacher => teacher.TeacherCourseGroupRelations)
            .FirstOrDefault();
    }
}
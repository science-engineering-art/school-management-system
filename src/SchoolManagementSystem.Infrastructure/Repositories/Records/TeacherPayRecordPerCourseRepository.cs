using SchoolManagementSystem.Application.Repositories_Interfaces.Records;

using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Persistence;
using SchoolManagementSystem.Infrastructure.Configurations.Records;
using SchoolManagementSystem.Infrastructure.Configurations.Relations;

namespace SchoolManagementSystem.Infrastructure.Repositories.Records
{
    public class TeacherPayRecordPerCourseRepository :  RecordRepository<TeacherPayRecordPerCourse>, ITeacherPayRecordPerCourseRepository
    {
        public TeacherPayRecordPerCourseRepository(IObjectContext context) : base(context)
        {
     
        }
    }

}

﻿
using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Student : SchoolMember
    {
        public Tuitor Tuitor { get; set; }
        public int Founds { get; set; }   
        public Education ScholarityLevel{ get; set; }
        public IList<StudentCourseGroupRelation> StudentCourseGroupRelations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Magnifinance.Data.Entities;
using Magnifinance.ViewModels;
using MAGNIFINANCE.Web.ViewModels;

namespace DutchTreat.Data
{
    public class MagnifinanceMappingProfile : Profile
    {
        public MagnifinanceMappingProfile()
        {


            CreateMap<Course, CourseViewModel>()
          .ForMember(m => m.Subjects, opt => opt.Ignore())
          .ReverseMap();

            CreateMap<Subject, SubjectViewModel>()
                .ForMember(m => m.SubjectTeacher, opt => opt.Ignore())
                .ForMember(m => m.SubjectGrade, opt => opt.Ignore())
                .ForMember(m => m.Course, opt => opt.Ignore())
                .ForMember(m => m.TotalStudents, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Student, StudentViewModel>()
                .ForMember(m => m.StudentCourse, opt => opt.Ignore())
                .ForMember(m => m.SubjectGrade, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Teacher, TeacherViewModel>()
                .ForMember(m => m.TeacherSubjects, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<SubjectGrade, SubjectGradeViewModel>()
                .ForMember(m => m.Subject, opt => opt.Ignore())
                .ForMember(m => m.Student, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}

using AutoMapper;
using TaskExaminantionSystem.Models;

namespace TaskExaminantionSystem.ViewModels.StudentView
{
    public class StudentProfiler : Profile
    {
        public StudentProfiler()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentCreateViewModel, Student>();
        }
    }
}

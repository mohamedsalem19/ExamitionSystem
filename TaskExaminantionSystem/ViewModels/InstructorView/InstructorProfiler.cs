using AutoMapper;
using TaskExaminantionSystem.Models;

namespace TaskExaminantionSystem.ViewModels.InstructorView
{
    public class InstructorProfiler : Profile
    {
        public InstructorProfiler()
        {
            CreateMap<Instructor, InstructorViewModel>();
            CreateMap<InstructorCreateViewModel, Instructor>();

        }
    }
}

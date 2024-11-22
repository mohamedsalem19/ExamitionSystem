using AutoMapper;
using TaskExaminantionSystem.Models;

namespace TaskExaminantionSystem.ViewModels.CourseView
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseViewModel>();

            CreateMap<CourseCreateViewModel, Course>();
        }
    }
}

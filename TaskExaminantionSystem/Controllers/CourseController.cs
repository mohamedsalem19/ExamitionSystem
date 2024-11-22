using Microsoft.AspNetCore.Mvc;
using TaskExaminantionSystem.Data.Repository;
using TaskExaminantionSystem.Models;
using TaskExaminantionSystem.Services;
using TaskExaminantionSystem.ViewModels.CourseView;

namespace TaskExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        IGRepository<Course> _courseRepository;

        public CourseController(IGRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public IEnumerable<CourseViewModel> GetAll()
        {
            var courses = _courseRepository.GetAll();

            var query = courses.ProjectTo<CourseViewModel>().ToList();

            return query;
        }
        [HttpGet("{id}")]
        public CourseViewModel GetById(int id)
        {
            var course = _courseRepository.Get(x => x.Id == id);

            var query = course.MapFirstOrDefault<CourseViewModel>();

            return query;
        }

        [HttpPost]

        public string CreateCourse(CourseCreateViewModel viewModel)
        {
            var courseMap = viewModel.Map<Course>();
            _courseRepository.Add(courseMap);
            _courseRepository.SaveChange();
            return "Added Sucess";
        }


        [HttpPut("{id}")]

        public string EditCourse(int id, [FromForm] CourseCreateViewModel courseEditViewModel)
        {
            Course editCourse = new Course { Id = id };
            if (editCourse is null)
            {
                return "Course Not Found";
            }

            editCourse.Name = courseEditViewModel.Name;
            editCourse.Duration = courseEditViewModel.Duration;
            editCourse.Description = courseEditViewModel.Description;
            editCourse.InstructorId = courseEditViewModel.InstructorId;

            _courseRepository.SaveInclude(editCourse,
                nameof(editCourse.Name),
                nameof(editCourse.Duration),
                nameof(editCourse.Description),
                nameof(editCourse.InstructorId)); _courseRepository.SaveChange();
            return "Updated Sucess ";
        }

        [HttpDelete]

        public string DeleteCourse(int id)
        {
            Course course = new Course { Id = id };
            _courseRepository.Delete(course);
            _courseRepository.SaveChange();
            return "Deleted Sucess";

        }



    }
}

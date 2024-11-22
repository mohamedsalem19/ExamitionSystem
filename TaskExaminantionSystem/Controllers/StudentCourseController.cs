using Microsoft.AspNetCore.Mvc;
using TaskExaminantionSystem.Data.Repository;
using TaskExaminantionSystem.Models;

namespace TaskExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        IGRepository<StudentCourse> _repository;

        public StudentCourseController(IGRepository<StudentCourse> repository)
        {
            _repository = repository;
        }

        [HttpPost]

        public string EnrollCourse(int CourseId, int StudentId)
        {
            StudentCourse studentCourse = new StudentCourse
            {
                CourseId = CourseId,
                StudentId = StudentId
            };

            _repository.Add(studentCourse);
            _repository.SaveChange();
            return "Student Register Course";

        }
    }
}

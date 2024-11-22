using Microsoft.AspNetCore.Mvc;
using TaskExaminantionSystem.Data.Repository;
using TaskExaminantionSystem.Models;
using TaskExaminantionSystem.Services;
using TaskExaminantionSystem.ViewModels.StudentView;

namespace TaskExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IGRepository<Student> _studentRepository;

        public StudentController(IGRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public IEnumerable<StudentViewModel> GetAll()
        {
            var students = _studentRepository.GetAll();

            var query = students.ProjectTo<StudentViewModel>().ToList();

            return query;
        }
        [HttpGet("{id}")]
        public StudentViewModel GetById(int id)
        {
            var student = _studentRepository.Get(x => x.Id == id);

            var query = student.MapFirstOrDefault<StudentViewModel>();

            return query;
        }

        [HttpPost]

        public string CreateStudent(StudentCreateViewModel viewModel)
        {
            var studentMap = viewModel.Map<Student>();
            _studentRepository.Add(studentMap);
            _studentRepository.SaveChange();
            return "AddedSucess";


        }



        [HttpDelete]

        public string DeleteInstructor(int id)
        {
            Student student = new Student { Id = id };
            _studentRepository.Delete(student);
            _studentRepository.SaveChange();
            return "Deleted Sucess";

        }
    }
}

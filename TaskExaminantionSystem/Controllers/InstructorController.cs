using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using TaskExaminantionSystem.Data.Repository;
using TaskExaminantionSystem.Models;
using TaskExaminantionSystem.Services;
using TaskExaminantionSystem.ViewModels.InstructorView;

namespace TaskExaminantionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        IGRepository<Instructor> _instructorRepository;

        public InstructorController(IGRepository<Instructor> instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        [HttpGet]
        public IEnumerable<InstructorViewModel> GetAll()
        {
            var instructors = _instructorRepository.GetAll();

            var query = instructors.ProjectTo<InstructorViewModel>().ToList();

            return query;
        }
        [HttpGet("{id}")]
        public InstructorViewModel GetById(int id)
        {
            var instructor = _instructorRepository.Get(x => x.Id == id);

            var query = instructor.MapFirstOrDefault<InstructorViewModel>();

            return query;
        }

        [HttpPost]

        public string CreateInstructor(InstructorCreateViewModel viewModel)
        {
            var instructorMap = viewModel.Map<Instructor>();
            _instructorRepository.Add(instructorMap);
            _instructorRepository.SaveChange();
            return "AddedSucess";


        }

        [HttpDelete]

        public string DeleteInstructor(int id)
        {
            Instructor instructor = new Instructor { Id = id };
            _instructorRepository.Delete(instructor);
            _instructorRepository.SaveChange();
            return "Deleted Sucess";

        }

    }
}

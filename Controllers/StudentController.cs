using Microsoft.AspNetCore.Mvc;
using PingoDeGenteAppApi.Infrastructure;
using PingoDeGenteAppApi.Model;
using StudentbookAppApi.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PingoDeGenteAppApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _studentRepository.GetAllStudents();
        }

        // GET api/student/5
        [HttpGet("{id}")]
        public async Task<Student> Get(string id)
        {
            return await _studentRepository.GetStudent(id) ?? new Student();
        }

        // POST api/student
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _studentRepository.AddStudent(student);
        }

        // DELETE api/student/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _studentRepository.RemoveStudent(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PingoDeGenteAppApi.Infrastructure;
using PingoDeGenteAppApi.Model;
using StudentbookAppApi.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PingoDeGenteAppApi.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public EstudanteController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View(_studentRepository.GetAllStudents().Result);
        }
    }
}

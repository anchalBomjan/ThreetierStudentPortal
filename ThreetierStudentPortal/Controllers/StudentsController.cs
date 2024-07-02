using Business.Layer.Service;
using Global.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ThreetierStudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            await _studentService.AddStudentAsync(viewModel);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            await _studentService.UpdateStudentAsync(student);
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student != null)
            {
                await _studentService.DeleteStudentAsync(student);
            }
            return RedirectToAction("List");
        }
    }
}

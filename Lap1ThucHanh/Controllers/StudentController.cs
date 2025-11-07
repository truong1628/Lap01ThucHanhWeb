using Lap1ThucHanh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lap1ThucHanh.Controllers
{
    [Route("admin/student")]
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>
        {
            new Student() { Id = 101, Name = "Hai Nam", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular = true,
                Address = "A1-2018", Email = "123@gmail.com" },
            new Student() { Id = 102, Name = "Minh Tu", Branch = Branch.BE,
                Gender = Gender.Female, IsRegular = true,
                Address = "A1-2019", Email = "123@gmail.com" },
            new Student() { Id = 103, Name = "Hoang Phong", Branch = Branch.CE,
                Gender = Gender.Male, IsRegular = false,
                Address = "A1-2020", Email = "123@gmail.com" },
            new Student() { Id = 104, Name = "Xuan Mai", Branch = Branch.EE,
                Gender = Gender.Female, IsRegular = true,
                Address = "A1-2021", Email = "123@gmail.com" }
        };

        [HttpGet("list")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet("add")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.Branches = new List<SelectListItem>
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "KT", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };

            return View();
        }
  
        [HttpPost("add")]

        public IActionResult Create(Student s, IFormFile? photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                var directory = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }

                s.Photo = fileName;
            }

            s.Id = listStudents.Last().Id + 1;
            listStudents.Add(s);

            return RedirectToAction("Index");
        }
    }
}

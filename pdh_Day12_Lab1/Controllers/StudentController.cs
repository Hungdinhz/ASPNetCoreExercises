using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pdh_Day12_Lab1.Models;

namespace pdh_Day12_Lab1.Controllers
{
    public class StudentController : Controller
    {

        private List<Student> students = new List<Student>();

        public StudentController() {
            students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Name = "Nguyen Van An",
                    Gender = Gender.Male,
                    Branch = Branch.IT,
                    Email = "an.nguyen@gmail.com",
                    Password = "123456",
                    IsRegular = true,
                    Address = "Ha Noi",
                    DateOfBorth = new DateTime(2002, 5, 10)
                },
                new Student()
                {
                    Id = 2,
                    Name = "Tran Thi Bich",
                    Gender = Gender.Female,
                    Branch = Branch.BE,
                    Email = "bich.tran@gmail.com",
                    Password = "654321",
                    IsRegular = false,
                    Address = "Hai Phong",
                    DateOfBorth = new DateTime(2003, 8, 21)
                },
                new Student()
                {
                    Id = 3,
                    Name = "Le Minh Hoang",
                    Gender = Gender.Male,
                    Branch = Branch.IT,
                    Email = "hoang.le@gmail.com",
                    Password = "abc123",
                    IsRegular = true,
                    Address = "Da Nang",
                    DateOfBorth = new DateTime(2001, 11, 2)
                },
                new Student()
                {
                    Id = 4,
                    Name = "Pham Thu Huong",
                    Gender = Gender.Female,
                    Branch = Branch.CE,
                    Email = "huong.pham@gmail.com",
                    Password = "design2024",
                    IsRegular = true,
                    Address = "Hue",
                    DateOfBorth = new DateTime(2004, 3, 14)
                },
                new Student()
                {
                    Id = 5,
                    Name = "Do Quang Huy",
                    Gender = Gender.Male,
                    Branch = Branch.EE,
                    Email = "huy.do@gmail.com",
                    Password = "mk123",
                    IsRegular = false,
                    Address = "Ho Chi Minh City",
                    DateOfBorth = new DateTime(2002, 12, 25)
                }
            };

        }

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult AboutMe()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Lay danh sach cac Gender de hien thi radio button tren form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            // Lay danh sach cac Branch de hien thi dropdown list tren form
            ViewBag.AllBranches = new List<SelectListItem>
            {
                new SelectListItem { Text = "Information Technology", Value = Branch.IT.ToString() },
                new SelectListItem { Text = "Kinh tế", Value = Branch.BE.ToString() },
                new SelectListItem { Text = "Công trình", Value = Branch.CE.ToString() },
                new SelectListItem { Text = "Diện tử", Value = Branch.EE.ToString() }
            };

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {

            s.Id = students.Max(st => st.Id) + 1;
            students.Add(s);
            return View("Index", students);
        }


    }
}

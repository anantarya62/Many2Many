using CRUD.Models;
using Many2Many;
using Many2Many.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Text.Json;

namespace CRUD.Controllers
{
    public class AdmissionController : Controller
    {
         private AppDbContext _db;
        public AdmissionController(AppDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Get Section of Student
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Index()
        {
            var studentModel = new List<StudentModel>();
            var student = _db.Students.ToList();
            foreach (var item in student)
            {
                studentModel.Add(new StudentModel{
                    Name = item.Name,
                    Enrolled = item.Enrolled });
            }
            
            return View(studentModel);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var student = _db.Students.Find(Id);
            StudentModel studentModel = new StudentModel
            {
                Name=student.Name,
                Enrolled=student.Enrolled
            };
            return View(studentModel);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var student = _db.Students.Where(x => x.Id == Id).FirstOrDefault();
            StudentModel studentModel = new StudentModel
            {
                Name = student.Name,
                Enrolled = student.Enrolled
            };
            return View(studentModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var courses = _db.Courses.Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();
            StudentModel model = new StudentModel();
            model.Courses=courses;
            return View(model);

        }

        /// <summary>
        /// Get Section of 
        /// </summary>
        /// <returns></returns>
        
        [HttpPost]
        public IActionResult Create(StudentModel model)
        {

            Student student = new Student
            {
                Name = model.Name,
                Enrolled = model.Enrolled,
            };
            var selectedCourse = model.Courses.Where(x => x.Selected).Select(y => y.Value).ToList();
            foreach (var item in selectedCourse)
            {
                student.Enrollment.Add(new StudentCourse()
                {
                    CourseId = int.Parse(item)

                });
            }

            _db.Students.Add(student);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}

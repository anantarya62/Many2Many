using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Enrolled { get; set; }
        public IList<SelectListItem> Courses { get; set; }
    }
}

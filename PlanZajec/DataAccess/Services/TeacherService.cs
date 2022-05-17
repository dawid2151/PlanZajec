using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PlanZajec.DataAccess.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationContext _context;

        public TeacherService(ApplicationContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetSelectListItems()
        {
            return _context.Teachers.Select(x =>
                new SelectListItem($"{x.Name} {x.Surname}", x.Id.ToString())).ToList();

        }
    }
}
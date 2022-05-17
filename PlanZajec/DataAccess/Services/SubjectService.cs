using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlanZajec.DataAccess.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationContext _context;

        public SubjectService(ApplicationContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetSelectListItems()
        {
            return _context.Subjects.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }
    }
}
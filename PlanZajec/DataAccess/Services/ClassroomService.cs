using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlanZajec.DataAccess.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly ApplicationContext _context;

        public ClassroomService(ApplicationContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetSelectListItems()
        {
            List<SelectListItem> selectList;
            selectList = _context.Classrooms.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            return selectList;
        }
    }
}
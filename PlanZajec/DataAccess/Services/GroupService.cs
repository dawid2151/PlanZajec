using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlanZajec.DataAccess.Services
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationContext _context;

        public GroupService(ApplicationContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetSelectListItems()
        {
            return _context.Groups.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlanZajec.DataAccess.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly ApplicationContext _context;

        public ActivityTypeService(ApplicationContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetSelectListItems()
        {
            return _context.ActivityTypes.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }
    }
}
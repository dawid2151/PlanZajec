using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlanZajec.DataAccess.Services
{
    public interface ITeacherService
    {
        public List<SelectListItem> GetSelectListItems();
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlanZajec.DataAccess.Services
{
    public interface IClassroomService
    {
        List<SelectListItem> GetSelectListItems();
    }
}
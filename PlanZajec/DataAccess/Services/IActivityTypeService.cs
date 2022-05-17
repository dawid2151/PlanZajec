using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlanZajec.DataAccess.Services
{
    public interface IActivityTypeService
    {
        List<SelectListItem> GetSelectListItems();
    }
}
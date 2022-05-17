using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlanZajec.DataAccess.Services
{
    public interface IGroupService
    {
        List<SelectListItem> GetSelectListItems();
    }
}
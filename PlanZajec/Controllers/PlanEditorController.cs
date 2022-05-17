using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlanZajec.DataAccess.Services;
using PlanZajec.Models;

namespace PlanZajec.Controllers
{
    public class PlanEditor : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ISubjectService _subjectService;
        private readonly IGroupService _groupService;
        private readonly IClassroomService _classroomService;
        private readonly ITeacherService _teacherService;
        private readonly IActivityTypeService _activityTypeService;

        public PlanEditor(ILessonService lessonService, IClassroomService classroomService,
            ISubjectService subjectService, IGroupService groupService, ITeacherService teacherService,
            IActivityTypeService activityTypeService)
        {
            _lessonService = lessonService;
            _classroomService = classroomService;
            _subjectService = subjectService;
            _groupService = groupService;
            _teacherService = teacherService;
            _activityTypeService = activityTypeService;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddLesson()
        {
            var model = new AddLessonViewModel();
            AssignSelectListItemsForDropdowns(model);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddLesson(AddLessonViewModel model)
        {
            bool saved = await _lessonService.SaveLessonAsync(model);
            if (saved)
                model.Message = "Pomyślnie dodano nową lekcję!";
            else
                model.Message = "Wystąpił problem, nie dodano lekcji.";
            AssignSelectListItemsForDropdowns(model);
            return View(model);
        }
        private void AssignSelectListItemsForDropdowns(AddLessonViewModel model)
        {
            model.ClassroomsSelectList = _classroomService.GetSelectListItems();
            model.SubjectsSelectList = _subjectService.GetSelectListItems();
            model.GroupsSelectList = _groupService.GetSelectListItems();
            model.TeachersSelectList = _teacherService.GetSelectListItems();
            model.ActivityTypeSelectList = _activityTypeService.GetSelectListItems();
        }
    }
}

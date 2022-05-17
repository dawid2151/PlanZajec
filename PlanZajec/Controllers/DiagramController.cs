using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanZajec.DataAccess.Services;
using PlanZajec.Models;

namespace PlanZajec.Controllers
{
    public class DiagramController : Controller
    {
        private readonly ILessonService _lessonService;

        public DiagramController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new DiagramIndexViewModel();
            var startingDate = new DateTime(2020, 01, 01);
            var endingDate = new DateTime(2023, 01, 01);
            var lessons = await _lessonService.GetLessonsInTimeframeAsync(startingDate, endingDate);
            viewModel.LessonViewModels = lessons.Select(x =>
                new LessonPartialViewModel()
                {
                    Classroom = x.Classroom.Name,
                    GroupName = x.Group.Name,
                    TeacherName = string.Format("{0} {1}", x.Teacher.Name, x.Teacher.Surname),
                    LessonName = x.Subject.Name,
                    ActivityType = x.ActivityType.Name,
                    StartingDate = x.StartingDate.ToString(),
                    EndingDate = x.EndingDate.ToString()
                }).ToList();
            //TODO: 
            return View(viewModel);
        }
    }
}
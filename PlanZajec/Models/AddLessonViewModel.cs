using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PlanZajec.Models
{
    public class AddLessonViewModel
    {
        public int GroupId { get; set; } 
        public int ClassroomId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int ActivityTypeId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        
        public List<SelectListItem> ClassroomsSelectList { get; set; }
        public List<SelectListItem> SubjectsSelectList { get; set; }
        public List<SelectListItem> GroupsSelectList { get; set; }
        public List<SelectListItem> TeachersSelectList { get; set; }
        public List<SelectListItem> ActivityTypeSelectList { get; set; }
        public string Message { get; set; }
    }
}
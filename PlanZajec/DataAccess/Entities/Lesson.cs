using System;

namespace PlanZajec.DataAccess.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int ClassroomId { get; set; }
        public int ActivityTypeId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
        public Group Group { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}
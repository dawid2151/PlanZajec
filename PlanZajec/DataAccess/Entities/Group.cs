using System.Collections;
using System.Collections.Generic;

namespace PlanZajec.DataAccess.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int FieldOfStudyId { get; set; }
        public string Name { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
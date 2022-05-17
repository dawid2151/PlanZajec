using System.Collections;
using System.Collections.Generic;

namespace PlanZajec.DataAccess.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        
        public ICollection<Lesson> Lessons { get; }
    }
}
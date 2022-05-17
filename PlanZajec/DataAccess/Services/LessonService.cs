using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanZajec.DataAccess.Entities;
using PlanZajec.Models;

namespace PlanZajec.DataAccess.Services
{
    public class LessonService : ILessonService
    {
        private readonly ApplicationContext _context;

        public LessonService(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Lesson>> GetLessonsInDayAsync(DateTime date)
        {
            return await _context.Lessons.Where(x => x.StartingDate.Date == date.Date).ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessonsInTimeframeAsync(DateTime from, DateTime to)
        {
            var query = _context.Lessons
                .Where(x => x.StartingDate >= from && x.StartingDate <= to)
                .Include(x => x.Teacher)
                .Include(x => x.Classroom)
                .Include(x => x.Group)
                .Include(x => x.Subject)
                .Include(x => x.ActivityType)
                .OrderBy(x => x.StartingDate);



            return query.ToList();
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            return await _context.Lessons.Where(x => x.Id == id).SingleAsync();
        }

        public async Task<bool> SaveLessonAsync(AddLessonViewModel lesson)
        {
            var lessonEntity = new Lesson
            {
                ClassroomId = lesson.ClassroomId,
                TeacherId = lesson.TeacherId,
                GroupId = lesson.GroupId,
                SubjectId = lesson.SubjectId,
                StartingDate = lesson.StartingDate,
                EndingDate = lesson.EndingDate,
                ActivityTypeId = lesson.ActivityTypeId
            };
            _context.Lessons.Add(lessonEntity);
            int modifiedCount = await _context.SaveChangesAsync();
            return modifiedCount == 1;
        }
    }
}
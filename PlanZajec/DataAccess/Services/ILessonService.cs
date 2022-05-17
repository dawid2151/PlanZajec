using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanZajec.DataAccess.Entities;
using PlanZajec.Models;

namespace PlanZajec.DataAccess.Services
{
    /// <summary>
    /// Service responsible for actions on <see cref="Lesson"/>
    /// </summary>
    public interface ILessonService
    {
        /// <summary>
        /// Get all lessons that have their <c>StartingDate</c> in <paramref name="date"/> day.
        /// </summary>
        /// <param name="date">Date representing given day</param>
        /// <returns>IEnumerable&lt;<see cref="Lesson"/>&gt;</returns>
        Task<IEnumerable<Lesson>> GetLessonsInDayAsync(DateTime date);
        /// <summary>
        /// Get all lessons that have their <c>StartingDate</c> in between dates: &lt; <paramref name="from"/>, <paramref name="to"/> &gt; inclusive
        /// </summary>
        /// <param name="from">starting DateTime</param>
        /// <param name="to">ending DateTime</param>
        /// <returns>IEnumerable&lt;<see cref="Lesson"/>&gt;</returns>
        Task<IEnumerable<Lesson>> GetLessonsInTimeframeAsync(DateTime from, DateTime to);
        Task<Lesson> GetLessonByIdAsync(int id);

        Task<bool> SaveLessonAsync(AddLessonViewModel lesson);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanZajec.DataAccess.Entities;

namespace PlanZajec.DataAccess
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Classroom>(x => x.ToTable("sale"));
            builder.Entity<Teacher>(x => x.ToTable("nauczyciel"));
            builder.Entity<Subject>(x => x.ToTable("przedmioty"));
            builder.Entity<Group>(x => x.ToTable("grupy"));
            builder.Entity<ActivityType>(x => x.ToTable("typ_zajec"));
            builder.Entity<Lesson>(x => x.ToTable("zajecia"));
            
            builder.Entity<Classroom>().Property(x => x.Id).HasColumnName("idSali");
            builder.Entity<Classroom>().Property(x => x.Name).HasColumnName("nazwa_sali");
            builder.Entity<Classroom>().Property(x => x.Description).HasColumnName("opis");

            builder.Entity<Group>().Property(x => x.Id).HasColumnName("idGrupy");
            builder.Entity<Group>().Property(x => x.Name).HasColumnName("nazwaGrupy");
            builder.Entity<Group>().Property(x => x.FieldOfStudyId).HasColumnName("idKierunek");

            builder.Entity<Subject>().Property(x => x.Id).HasColumnName("idPrzedmiotu");
            builder.Entity<Subject>().Property(x => x.Name).HasColumnName("nazwa");
            builder.Entity<Subject>().Property(x => x.Remarks).HasColumnName("uwagi");
            builder.Entity<Subject>().Property(x => x.Requirements).HasColumnName("wymagania");

            builder.Entity<Teacher>().Property(x => x.Id).HasColumnName("idNauczyciela");
            builder.Entity<Teacher>().Property(x => x.Name).HasColumnName("imie");
            builder.Entity<Teacher>().Property(x => x.Surname).HasColumnName("nazwisko");
            builder.Entity<Teacher>().Property(x => x.PhoneNumber).HasColumnName("telefon_kom");

            builder.Entity<ActivityType>().Property(x => x.Id).HasColumnName("idTypuZajec");
            builder.Entity<ActivityType>().Property(x => x.Name).HasColumnName("nazwa_typu");

            builder.Entity<Lesson>().Property(x => x.Id).HasColumnName("idZajec");
            builder.Entity<Lesson>().Property(x => x.ClassroomId).HasColumnName("idSali");
            builder.Entity<Lesson>().Property(x => x.GroupId).HasColumnName("idGrupy");
            builder.Entity<Lesson>().Property(x => x.SubjectId).HasColumnName("idPrzedmiotu");
            builder.Entity<Lesson>().Property(x => x.TeacherId).HasColumnName("idNauczyciela");
            builder.Entity<Lesson>().Property(x => x.ActivityTypeId).HasColumnName("idTypZajec");
            builder.Entity<Lesson>().Property(x => x.StartingDate).HasColumnName("od");
            builder.Entity<Lesson>().Property(x => x.EndingDate).HasColumnName("do");

            builder.Entity<Lesson>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.Lessons)
                .HasForeignKey(x=> x.TeacherId)
                .IsRequired();
            builder.Entity<Lesson>()
                .HasOne(x => x.Classroom)
                .WithMany()
                .HasForeignKey(x=> x.ClassroomId)
                .IsRequired();
            builder.Entity<Lesson>()
                .HasOne(x => x.Group)
                .WithMany(x=> x.Lessons)
                .HasForeignKey(x=> x.GroupId)
                .IsRequired();
            builder.Entity<Lesson>()
                .HasOne(x => x.Subject)
                .WithMany()
                .HasForeignKey(x=> x.SubjectId)
                .IsRequired();
            builder.Entity<Lesson>()
                .HasOne(x => x.ActivityType)
                .WithMany()
                .HasForeignKey(x => x.ActivityTypeId)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
        }
    }
}
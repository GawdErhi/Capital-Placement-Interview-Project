using CapitalPlacementInterviewProject.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacementInterviewProject.API.DB
{
    public class ProjectDBContext : DbContext
    {

        public DbSet<QuestionType> QuestionTypes { get; set; }

        public DbSet<ProgramDetailQuestionTypeChoice> ProgramDetailQuestionTypeChoices { get; set; }

        public DbSet<ProgramDetailQuestionType> ProgramDetailQuestionTypes { get; set; }

        public DbSet<ProgramDetailPersonalInfoField> ProgramDetailPersonalInfoFields { get; set; }

        public DbSet<ProgramDetail> ProgramDetails { get; set; }

        public DbSet<ProgramCandidateQuestionTypeAnswer> ProgramCandidateQuestionTypeAnswers { get; set; }

        public DbSet<ProgramCandidate> ProgramCandidates { get; set; }

        public DbSet<PersonalInfoField> PersonalInfoFields { get; set; }

        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionType>()
                .ToContainer(nameof(this.QuestionTypes))
                .HasPartitionKey(x => x.Id)
                .HasDiscriminator();

            modelBuilder.Entity<ProgramDetailQuestionTypeChoice>()
                .ToContainer(nameof(this.ProgramDetailQuestionTypeChoices))
                .HasPartitionKey(x => x.Id)
                .HasDiscriminator();

            modelBuilder.Entity<ProgramDetailQuestionType>()
                .ToContainer(nameof(this.ProgramDetailQuestionTypes))
                .HasPartitionKey(x => x.Id)
                .HasDiscriminator();

            modelBuilder.Entity<ProgramDetailPersonalInfoField>()
                .ToContainer(nameof(this.ProgramDetailPersonalInfoFields))
                .HasPartitionKey(x => x.Id)
                .HasDiscriminator();

            modelBuilder.Entity<ProgramDetail>()
                .ToContainer(nameof(this.ProgramDetails))
                .HasPartitionKey(x => x.Id)
                .HasDiscriminator();

            modelBuilder.Entity<ProgramCandidateQuestionTypeAnswer>()
                .ToContainer(nameof(this.ProgramCandidateQuestionTypeAnswers))
                .HasPartitionKey(x => x.Id)
                .HasDiscriminator();

            modelBuilder.Entity<ProgramCandidate>()
                .ToContainer(nameof(this.ProgramCandidates))
                .HasPartitionKey(x => x.Id)
                .HasDiscriminator();

            modelBuilder.Entity<PersonalInfoField>()
                .ToContainer(nameof(this.PersonalInfoFields))
                .HasPartitionKey(x => x.Id)
                .HasDiscriminator();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tool.Server.Model;
public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<IdentityUser> User { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Quiz> Quizs { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionType> QuestionTypes { get; set; }
    public DbSet<QuizReport> QuizReports { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<UserAnswerMapping> UserAnswerMappings { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Question>()
            .HasOne(e => e.Quiz)
            .WithMany(e => e.Questions)
            .HasForeignKey(e => e.QuizId);

        modelBuilder.Entity<Score>()
            .HasOne(e => e.User)
            .WithMany(e => e.Scores)
            .HasForeignKey(e => e.Id);

        modelBuilder.Entity<Score>()
        .HasOne(e => e.Quiz)
        .WithMany(e => e.Scores)
        .HasForeignKey(e => e.QuizId);
    }

}
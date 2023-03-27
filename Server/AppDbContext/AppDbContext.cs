using Microsoft.EntityFrameworkCore;
using System;
using Tool.Server.Model;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizs { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionType> QuestionTypes { get; set; }
    public DbSet<QuizReport> QuizReports { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<UserAnswerMapping> UserAnswerMappings { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>()
            .HasOne(e => e.Quiz)
            .WithMany(e => e.Questions)
            .HasForeignKey(e => e.QuizId);

    }

}
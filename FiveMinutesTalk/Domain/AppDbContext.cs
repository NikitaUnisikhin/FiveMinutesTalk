using FiveMinutesTalk.Domain.Entities;
using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FiveMinutesTalk.Domain;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Quiz> Quizzes;
    public DbSet<Question> Questions;
    public DbSet<QuizQuestion> QuizQuestions;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
            Name = "authorizedUser",
            NormalizedName = "AUTHORIZEDUSER"
        });

        builder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "my@email.com",
            NormalizedEmail = "MY@EMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
            SecurityStamp = string.Empty
        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
            UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
        });

        builder.Entity<Question>().HasData(new Question()
        {
            Id = new Guid("92EF0486-B6C5-4706-A9C8-2C994F43159D"),
            Text = "Как зовут альфу?",
            CorrectAnswers = new [] { "Саша" },
            Type = QuestionTypeEnum.OpenQuestion
        });
        
        builder.Entity<Question>().HasData(new Question()
        {
            Id = new Guid("8B95163B-8485-40D6-BAFD-51785AD6E9D2"),
            Text = "Назови имена создателей сайта?",
            AnswerOptions = new [] { "Саша", "Никита", "Сша" },
            CorrectAnswers = new [] { "Саша", "Никита" },
            Type = QuestionTypeEnum.MultipleAnswersQuestion
        });

        builder.Entity<Quiz>().HasData(new Quiz()
        {
            Id = new Guid("4043B854-C29F-4DCA-900C-0387DE52D250"),
            Title = "Как хорошо ты знаешь создателей?"
        });

        builder.Entity<QuizQuestion>().HasData(new QuizQuestion()
        {
            Id = new Guid("51006146-DE9B-4D6E-A2D0-DEB2C1874434"),
            QuizId = new Guid("4043B854-C29F-4DCA-900C-0387DE52D250"),
            QuestionId = new Guid("8B95163B-8485-40D6-BAFD-51785AD6E9D2")
        });
        
        builder.Entity<QuizQuestion>().HasData(new QuizQuestion()
        {
            Id = new Guid("B1FCFF97-0713-4815-B3A8-40232DB7FF90"),
            QuizId = new Guid("4043B854-C29F-4DCA-900C-0387DE52D250"),
            QuestionId = new Guid("92EF0486-B6C5-4706-A9C8-2C994F43159D")
        });
    }
}
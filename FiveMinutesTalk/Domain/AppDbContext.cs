using FiveMinutesTalk.Domain.Entities;
using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FiveMinutesTalk.Domain;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<QuizQuestionAnswer> QuizQuestionAnswers { get; set; }
    public DbSet<QuizAnswer> QuizAnswers { get; set; }
        
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "A09B4B9F-27F3-47C4-B83B-CEE4C5C5C874",
            Name = "admin",
            NormalizedName = "ADMIN"
        });

        builder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC",
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
            RoleId = "A09B4B9F-27F3-47C4-B83B-CEE4C5C5C874",
            UserId = "BCF8F1A1-A9BA-480F-A16C-88DBDCFAA9AC"
        });
        
        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "C8F61226-0EE8-4AEB-9C57-BE198614A1E8",
            Name = "user",
            NormalizedName = "USER"
        });

        builder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
            UserName = "nikita",
            NormalizedUserName = "NIKITA",
            Email = "my@email.com",
            NormalizedEmail = "MY@EMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "nikita"),
            SecurityStamp = string.Empty
        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "C8F61226-0EE8-4AEB-9C57-BE198614A1E8",
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
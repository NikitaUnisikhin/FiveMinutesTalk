using FiveMinutesTalk.Domain;
using FiveMinutesTalk.Domain.Entities;
using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;
using FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;
using FiveMinutesTalk.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Configuration.Bind("Project", new Config());

builder.Services.AddTransient<IRepository<Question>, EFQuestionsRepository>();
builder.Services.AddTransient<IRepository<Quiz>, EFQuizzesRepository>();
builder.Services.AddTransient<IRepository<QuizQuestion>, EFQuizQuestionsRepository>();
builder.Services.AddTransient<IRepository<QuestionAnswer>, EFQuestionAnswersRepository>();
builder.Services.AddTransient<IRepository<QuizAnswer>, EFQuizAnswerRepository>();
builder.Services.AddTransient<IRepository<QuizQuestionAnswer>, EFQuizQuestionAnswerRepository>();
builder.Services.AddTransient<DataManager>();

builder.Services.AddDbContext<AppDbContext>(x => x.UseNpgsql(Config.ConnectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "auth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("UserArea", policy => { policy.RequireRole("user"); });
});

builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new UserAreaAuthorization("User", "UserArea"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "user",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
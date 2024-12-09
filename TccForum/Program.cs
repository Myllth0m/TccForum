using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TccForum.Data;
using TccForum.Services.Pergunta;
using TccForum.Services.Resposta;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "ForumCookie";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(4);
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("UsuarioPadrao", policy => policy.RequireRole("UsuarioPadrao"))
    .AddPolicy("UsuarioPremium", policy => policy.RequireRole("UsuarioPremium"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IPerguntaInterface, PerguntaService>();
builder.Services.AddScoped<IRespostaInterface, RespostaService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//using Board.Application.AppData;
//using Board.Application.AppData.Posts.Services;
//using Board.Contracts;
//using Board.Contracts.Posts;


using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;



using Board.Application.AppData;
using Board.Application.AppData.Posts.Services;
using Board.Contracts;
using Board.Contracts.Posts;
using Board.Infrastructure.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Добавляем DbContext
builder.Services.AddSingleton<IDbContextConfiguration<BoardDbContext>, BoardDbContextConfiguration>();

builder.Services.AddDbContext<BoardDbContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
    ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<BoardDbContext>>()
        .Configure((DbContextOptionsBuilder<BoardDbContext>)dbOptions)));

builder.Services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<BoardDbContext>()));




// Add services to the container.
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<IForbiddenWordsService, ForbiddenWordsService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Posts Api", Version = "V1" });
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
        $"{typeof(CreatePostDto).Assembly.GetName().Name}.xml")));
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "Documentation.xml")));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

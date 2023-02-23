using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration["ConnectionString:TicketingSystemDB"];//connection string from appsetting.json
builder.Services.AddDbContext<UserContext>(opts =>
                                                 opts.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IIssueService,IssueService>();
builder.Services.AddScoped<IProjectService,ProjectService>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

using MAS.Project.Configuration;
using MAS.Project.Services;

const string AllowAllCorsOriginsForDev = "AllowAllCorsOriginsForDev";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBackendServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAllCorsOriginsForDev,
        policy => policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("https://localhost:5173")
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
    app.UseCors(AllowAllCorsOriginsForDev);
else
    app.UseCors();

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Lifetime.ApplicationStarted.Register(
    () => {
        using var scope = app.Services.CreateScope();
        scope.ServiceProvider.GetService<SampleDataService>()!.Seed();
    });

app.Run();

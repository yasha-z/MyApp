using Session1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBookService, BookService>();

var app = builder.Build();

InMemoryStore.SeedData();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// TASK 2.4 — Register request logging middleware
app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();

app.Run();

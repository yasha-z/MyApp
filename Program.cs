using Session1;
//thiis divides the code into two parts, the first part is register services
// second part is the execution of the application, the middleware
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //this says that my app will use controllers
builder.Services.AddEndpointsApiExplorer();// this is for swagger to discover the endpoints
//get / post etc wagera swaggers needs to know what endpoints are available in the application

builder.Services.AddSwaggerGen(); //for swagger to generate the documentation for the endpoints
//jese terminal pr localhost aiga to test


// addsingleton: create ONE object for the entire application's lifetime.
//this means we are using same object  for the entire application lifetime, so if we add a book it will be available for the entire application lifetime
builder.Services.AddSingleton<IBookService, BookService>();

var app = builder.Build();

InMemoryStore.SeedData();

//  PART 2: Configure middleware pipeline 
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

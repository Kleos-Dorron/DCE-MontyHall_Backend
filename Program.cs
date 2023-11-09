using MontyHall_Backend.Services; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    //Defines to Include the APIComments.XMl to Swagger API
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "APIComments.xml"));
});

// Add a CORS policy to the application's services
builder.Services.AddCors(options =>
{
    // Add a default policy to the options
    options.AddDefaultPolicy(policybuilder =>
    {
        // Allow any origin
        policybuilder.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>());

        // Allow any header
        policybuilder.AllowAnyHeader();

        // Allow any method
        policybuilder.AllowAnyMethod();
 
    });
});

// Register the MontyHallService
builder.Services.AddTransient<MontyHallService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

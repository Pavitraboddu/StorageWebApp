using StorageWebApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<BlobRepository>(BlobRepository => new BlobRepository("DefaultEndpointsProtocol=https;AccountName=pavitrastorage;AccountKey=W0zwHK3hjFqHGy7t29go1HamiPlAIZP0Kkj8ccLcqs0YEgSqx0YVmWds7NAMaQjYYTs+dmfK3y7p+AStrBCI5A==;EndpointSuffix=core.windows.net","pavitracontainer"));
builder.Services.AddScoped<ITableStorageRepository, TableStorageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

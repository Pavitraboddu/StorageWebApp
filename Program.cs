using StorageWebApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<BlobRepository>(BlobRepository => new BlobRepository("DefaultEndpointsProtocol=https;AccountName=pavitrastorage;AccountKey=mk+02W72sM+UqL3p81KsIFjEpDDpb32Ezu/j1sIo+AFT9OZRAzq0/LCRQLnJR5u/RfZusgdcvBbN+AStDJt7Pw==;EndpointSuffix=core.windows.net", "pavitracontainer"));
builder.Services.AddScoped<ITableStorageRepository, TableStorageRepository>();
builder.Services.AddScoped<IFileShareRepository, FileShareRepository>();
builder.Services.AddScoped<IQueueRepository, QueueRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

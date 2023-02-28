using StorageWebApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<BlobRepository>(BlobRepository => new BlobRepository("DefaultEndpointsProtocol=https;AccountName=pavitrastorage;AccountKey=WcP5EsCxivIaTnTIv0N1knfFU8s76p9A5fjvXfXhuw5nofUdiYO4geSUFpCUsR978aSmKxFPlTNC+AStk9CrmA==;EndpointSuffix=core.windows.net", "pavitracontainer"));
builder.Services.AddScoped<IFileShareRepository, FileShareRepository>();
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

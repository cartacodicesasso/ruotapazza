using LanguageExt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost<IEnumerable<int?>, IEnumerable<string>>("/", DeleteMe.MapToString);
app.MapPost<object, Unit>("/paypal", PayPal.HandleEvent);

app.MapGet("/v", () => "v0.0.4");

app.Run();
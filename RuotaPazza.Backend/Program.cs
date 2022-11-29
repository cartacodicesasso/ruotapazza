var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Map("/api", builder =>
{
    builder.UseRouting();
    builder.UseEndpoints(api =>
    {
        api.MapPost("/donations", () => @"{ ""success"": true }");
        api.MapGet("/v", () => "v0.0.8");
    });
});

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();

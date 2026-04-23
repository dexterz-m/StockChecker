using Microsoft.EntityFrameworkCore;
using FreezerInventory.Data;
using FreezerInventory.Models;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=freezer.db"));

// Cors part
builder.Services.AddCors(options =>
{
    options.AddPolicy("allowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// static files part
app.UseDefaultFiles();
app.UseStaticFiles();

// Cors part
app.UseCors("allowAll");

// API nd points
app.MapGet("/items", async (AppDbContext db) =>
    await db.FreezerItems.ToListAsync());

app.MapPost("/items", async (AppDbContext db, FreezerItem item) =>
{
    db.FreezerItems.Add(item);
    await db.SaveChangesAsync();
    return Results.Ok(item);
});

app.MapDelete("/items/{id}", async (AppDbContext db, int id) =>
{
    var item = await db.FreezerItems.FindAsync(id);
    if (item is null) return Results.NotFound();

    db.FreezerItems.Remove(item);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
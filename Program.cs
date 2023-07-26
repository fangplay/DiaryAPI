using Microsoft.EntityFrameworkCore;
using DiaryAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DiaryContext>(opt =>
    opt.UseInMemoryDatabase("Diary"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using DiaryAPI.DB;

app.MapGet("/dairies/{id}", (int id) => DiaryDB.GetDiary(id));
app.MapGet("/diaries", () => DiaryDB.GetDiaries());
app.MapPost("/diaries", (Diary diary) => DiaryDB.CreateDiary(diary));
app.MapPut("/diaries", (Diary diary) => DiaryDB.UpdateDiary(diary));
app.MapDelete("/diaries/{id}", (int id) => DiaryDB.RemoveDiary(id));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

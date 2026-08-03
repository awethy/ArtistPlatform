using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Application.Services;
using ArtistPlatform.Application.Validators.Album;
using ArtistPlatform.Application.Validators.Artist;
using ArtistPlatform.Application.Validators.Post;
using ArtistPlatform.Application.Validators.Track;
using ArtistPlatform.Domain.Interfaces;
using ArtistPlatform.Infrastructure.Persistence;
using ArtistPlatform.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateArtistRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateArtistRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAlbumRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAlbumRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTrackRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTrackRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePostRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdatePostRequestValidator>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Artist Platform API",
        Version = "v1",
        Description = "API for managing artists and their information."
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();

builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumService, AlbumService>();

builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ITrackService, TrackService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();


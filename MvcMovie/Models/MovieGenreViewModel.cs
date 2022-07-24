namespace MvcMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class MovieGenreViewModel
{

    public List<Movie>? Movies { get; set; }
    public SelectList? Genres { get; set; }
    public string? SearchString { get; set; }
    public string? MovieGenre { get; set; }
}
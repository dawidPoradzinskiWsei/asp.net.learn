using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MoviesDP.Models;
using MoviesDP.Models.Movies;

namespace MoviesDP.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieServices _movieServices;

    public HomeController(ILogger<HomeController> logger, IMovieServices movieServices)
    {
        _logger = logger;
        _movieServices = movieServices;
    }

    public IActionResult Index(int page = 1, int size = 20)
    {
        if(page < 1)
        {
            page = 1;
        }
        if(size < 1)
        {
            size = 20;
        }
        return View(_movieServices.GetMoviesByPages(page, size));
    }

    public IActionResult Details(int id, int page = 1, int size = 20)
    {
        var movie = _movieServices.GetMovie(id);

        if(movie == null)
        {
            return NotFound();
        }

        var movieCasts = _movieServices.GetMovieCastsByPages(page, size, id);
        var model = new MovieAndCast
        {
            Movie = movie,
            MovieCasts = movieCasts
        };

        return View(model);
    }

    public IActionResult Privacy()
    {   
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

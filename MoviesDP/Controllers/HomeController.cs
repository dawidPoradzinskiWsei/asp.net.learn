using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesDP.Models;
using MoviesDP.Models.Movies;

namespace MoviesDP.Controllers;

public class HomeController : Controller
{
    private readonly IMovieServices _movieServices;

    public HomeController(IMovieServices movieServices)
    {
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

    public IActionResult Details(int id, int page = 1, int size = 8)
    {
        var movie = _movieServices.GetMovie(id);

        if(movie == null)
        {
            return NotFound();
        }
        if(page < 1)
        {
            page = 1;
        }
        if(size < 1)
        {
            size = 20;
        }
        var movieCasts = _movieServices.GetMovieCastsByPages(page, size, id);
        var model = new MovieAndCast
        {
            Movie = movie,
            MovieCasts = movieCasts
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult AddPerson(int id)
    {
        ViewData["MovieId"] = id;
        // ViewData["PersonId"] = 4;
        return View();
    }
    [HttpPost]
    [Authorize]
    public IActionResult AddPerson(int id, PersonEntity personEntity)
    {
        if(ModelState.IsValid)
        {
            _movieServices.AddPerson(personEntity);
            return RedirectToAction(nameof(Details) , new { id = id });
        }
        return View(personEntity);
    }
}

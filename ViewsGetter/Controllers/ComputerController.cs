using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ComputerController : Controller{

    private readonly IComputerService _computerService;

    public ComputerController(IComputerService computerService) {
        _computerService = computerService;
    }


    public IActionResult Index() {
        return View(_computerService.GetAll());
    }

    [HttpGet]
    public IActionResult Create() {

        Computer model = new Computer();
        string name = _computerService.GetOrganizations().ToString();
        Debug.WriteLine(name);
        model.Organizations = _computerService.GetOrganizations().Select(e => new SelectListItem(){Text = e.Name, Value = e.Id.ToString()}).ToList();


        return View(model);
    }

    [Authorize(Roles = "admin")]
    public ActionResult Details(int id) {
        return View(_computerService.GetById(id));
    }


    [HttpPost]
    public IActionResult Create(Computer model) { 
        if (ModelState.IsValid)
        {
            _computerService.Add(model);
            return RedirectToAction(nameof(Index));
        } else {
            return View();
        }
    }


    [HttpGet]
    public ActionResult Edit(int id)
    {
        return View(_computerService.GetById(id));
    }

    [HttpPost]
    public ActionResult Edit(Computer model) {
        if(!ModelState.IsValid) {
            return View();
        }
        _computerService.Update(model);
        return RedirectToAction(nameof(Index));
    }

    public ActionResult Delete(int id, Computer model) {
        _computerService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

}
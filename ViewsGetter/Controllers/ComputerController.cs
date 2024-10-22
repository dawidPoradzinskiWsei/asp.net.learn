using Microsoft.AspNetCore.Mvc;

public class ComputerController : Controller{

    static Dictionary<int, Computer> _computers = new();


    public IActionResult Index() {
        return View(_computers);
    }

    [HttpGet]
    public IActionResult Create() {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Computer model) { 
        if (ModelState.IsValid)
        {
            int id = _computers.Keys.Count != 0 ? _computers.Keys.Max() : 0;
            model.id = id + 1;
            _computers.Add(model.id, model);

            return RedirectToAction("Index");
        } else {
            return View(model);
        }
    }


    [HttpGet]
    public String Edit(int? id)
    {
        return "Edycja " + id;
    }

    [HttpGet]
    public IActionResult Delete(int? id) {
        _computers.Remove((int)id);
        return RedirectToAction("Index");
    }


}
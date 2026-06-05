using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectWithDatabase1.Models;

namespace ProjectWithDatabase1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly DatabaseForProject1Context context;
    public HomeController(ILogger<HomeController> _logger, DatabaseForProject1Context _context)
    {
        logger = _logger;
        context = _context;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ListData()
    {
        List<Student> std = context.Students.ToList();
        return View(std); 
    }


    public IActionResult Details(int? id)
    {
        if(id != null)
        {
            Student std = context.Students.FirstOrDefault(item => item.Roll == id);
            if(std != null)
            {
                return View(std);
            }
            else
            {
                TempData["message"] = "Id is not in record";
                return RedirectToAction("ListData");
            }
        }
        else
        {
            TempData["message"] = "Id can't be null";
            return RedirectToAction("ListData");
        }
       
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

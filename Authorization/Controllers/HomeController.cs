using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Task.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDatabase _database;
    private readonly ApplicationDbContext _dataset;


    public HomeController(ILogger<HomeController> logger, IDatabase database , ApplicationDbContext database1)
    {
        _logger = logger;
        _database=database;
        _dataset=database1;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(Register register)
    {
        if(ModelState.IsValid)
        {
             _database.AddRegister(register);
             return RedirectToAction("Privacy");

        }
        return View();
      
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Login()
    {
            return View();
    }
    [HttpPost]
    public IActionResult Login(Login login)
    {
        if (ModelState.IsValid)
        {
            
            return RedirectToAction("Index");
        }

        
        return View(login);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpGet]
    public IActionResult Signin()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Signin(Signin signin)
    {
        _dataset.User.Add(signin);
        _dataset.SaveChanges();
        return View("Signup");
    }
    [HttpGet]
    public IActionResult Signup()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Signup(Signin signin)
    {
        ClaimsIdentity identity=null;
        bool IsAuthenticate=false;
        
        var role=_dataset.User.Where(s => s.EmployeeId==signin.EmployeeId & s.Password==signin.Password  & s.EmployeeName==signin.EmployeeName ).FirstOrDefault();
        if(!string.IsNullOrEmpty(Convert.ToString(role)))
        {
             identity=new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,signin.EmployeeName),
                new Claim(ClaimTypes.Role,role.Role)
            },CookieAuthenticationDefaults.AuthenticationScheme);
            IsAuthenticate=true;
        
            if(IsAuthenticate)
        {
             
            var principal= new ClaimsPrincipal(identity);
            var login= HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
           return RedirectToAction("Index",$"{role.Role}");
        }
        }

        ViewBag.Message="Incorrect Credentials";
        return View();
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace Task.Controllers;
[Authorize(Roles ="Admin")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly IDatabase _database;
    private readonly ApplicationDbContext _dataset;


    public AdminController(ILogger<AdminController> logger, IDatabase database , ApplicationDbContext database1)
    {
        _logger = logger;
        _database=database;
        _dataset=database1;
    }
    
    public IActionResult Index()
    {
        return View();
    }
  
}
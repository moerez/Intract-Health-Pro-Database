using System.Diagnostics;
using InteractHealthProDatabase.Data;
using InteractHealthProDatabase.Models;
using InteractHealthProDatabase.Services;
using MailKit.Net.Imap;
using Microsoft.AspNetCore.Mvc;

namespace InteractHealthProDatabase.Controllers;

public class HomeController : Controller
{
    private readonly IhpDbContext _context;
    private readonly ILogger<HomeController> _logger;
    private readonly ImapClient _imapClient;
    private readonly IConfiguration _configuration;

    public HomeController(IhpDbContext context, ILogger<HomeController> logger, IConfiguration configuration, ImapClient imapClient)
    {
        _context = context;
        _logger = logger;
        _imapClient = imapClient;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return View(new EventViewModel());
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

    public JsonResult GetEvents(DateTime start, DateTime end)
    {
        EventService eventService = new EventService(_context, _imapClient, _configuration, _logger);
        return Json(eventService.GetEvents());
    }
}

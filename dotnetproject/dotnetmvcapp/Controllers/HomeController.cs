using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetmvcapp.Models;
using dotnetmvcapp.Services;

namespace dotnetmvcapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAccountService _accountService;

    public HomeController(ILogger<HomeController> logger,IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    public IActionResult Index()
    {
        return View();
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

    public async Task<IActionResult> Test()
    {
        var resp = await _accountService.Login(new Login{Email="jafrin@gmail.com",
                                            Password="admin@123"});
        Console.WriteLine(resp.token);
        return View();
    }
}

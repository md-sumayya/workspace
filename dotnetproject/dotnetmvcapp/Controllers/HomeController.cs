using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetmvcapp.Models;
using dotnetmvcapp.Services;


namespace dotnetmvcapp.Controllers
{
    public class HomeController : Controller 
    {
        private readonly IAccountService _accountService;
        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }
      
        public IActionResult Index()
        {
          return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login login)
        {
            if (ModelState.IsValid)
            {
                // Validate the login credentials
                // You can use your service or repository to check the credentials here
                var response =await _accountService.Login(login);

                if (response.token!=null)
                {
                    HttpContext.Session.SetString("AuthToken", response.token);

                    // Redirect to the dashboard page
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                }
            }
            return View(login);
        }

        public IActionResult Dashboard()
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
}
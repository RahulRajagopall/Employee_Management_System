using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ems.Models;
using Microsoft.AspNetCore.Authorization;

namespace ems.Controllers;
[Log]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
    

    public IActionResult About()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(Employee employee)
    {
        Repository repository=new Repository();
        bool adminValid=repository.IsValidAdmin(employee);
        bool employeeValid=repository.IsValidEmployee(employee);
        if(adminValid)
        {
            CookieOptions cookieOptions =new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Logintime",DateTime.Now.ToString(),cookieOptions);
            TempData["Cookies"]="Last Login : "+Request.Cookies["Logintime"];
            return RedirectToAction("Options","Admin");
        }
        else if(employeeValid)
        {       
            HttpContext.Session.SetString("userId",Convert.ToString(employee.UserId));
            CookieOptions cookieOptions =new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Logintime",DateTime.Now.ToString(),cookieOptions);
            TempData["Cookies"]="Last Login : "+Request.Cookies["Logintime"];
            return RedirectToAction("Index","User"); 
        }        
        else
        {        
            ViewBag.InvalidUserMessage="Invalid Username/Password";
            return View();
        }
    }   

   [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }
     [HttpPost]
     public IActionResult ForgotPassword(Employee employee)
     {
        Repository repository=new Repository();
        string temp=repository.ChangePassword(employee);
        if(temp == "Success"){
            ViewBag.Success ="Password Successfully changed";
            return View("Login");}
        else if(temp=="notExist"){
            ViewBag.InvalidID ="Incorrect Email ID. Please try again";
            return View();}
        else if(temp=="notEquals"){
            ViewBag.NotMatching="Passwords does not match. Please try again";
            return View();}
        else{
            ViewBag.InvalidRegex ="Invalid entry";
            return View();}
     }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}

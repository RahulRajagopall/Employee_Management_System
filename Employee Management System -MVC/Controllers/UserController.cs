using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ems.Models;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ems.Controllers;

namespace ems.Controllers;
[Log]
public class UserController : Controller
{
   private readonly AdminDbContext admindb;
   public UserController(AdminDbContext database)
   {
      admindb = database;
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
   public IActionResult Profile()
   { 
      Repository repository=new Repository();
      string? Temp= HttpContext.Session.GetString("userId");
      Employee employee=repository.SearchEmployee(Convert.ToInt32(Temp));
      return View("ProfileResult",employee);
   }      
   public IActionResult Complaint()
   {
        return View();
   }
   [HttpPost]
   public async Task<IActionResult> ComplaintAsync(ComplaintModel complaintModel)
   {
      if(complaintModel.Email == null || complaintModel.Complaints == null)
      {
         ViewBag.EmptyFeildMessage="Please fill the feilds before Submitting";
         return View();
      }
      else
      {      
        try
            {
                HttpClient httpClient=new HttpClient();
               string apiUrl="http://localhost:5269/API/Operations";
               var jsondata = JsonConvert.SerializeObject(complaintModel);
               var data = new StringContent(jsondata,Encoding.UTF8,"application/json");
               var httpresponse=httpClient.PostAsync(apiUrl,data);
               var result = await httpresponse.Result.Content.ReadAsStringAsync();
               if(result=="true")
               {
                  ViewBag.ComplaintMessage="Complaint Registered";
                  return View();
               }
            }
               catch(Exception exception){
               ViewBag.Message2="Failed";
               Console.WriteLine(exception.Message);              
               return View();
            }            
      }   
   return View("Index");
   }
   public IActionResult ViewTask()
   {
      IEnumerable<TaskBase> task = admindb.TaskBase;  
      return View(task);           
   }
   public IActionResult Mail()
   {
     return View();
   }
   public IActionResult LogOut()
   {
      HttpContext.Session.Remove("userId");
      return RedirectToAction("Index","Home");
   }
}

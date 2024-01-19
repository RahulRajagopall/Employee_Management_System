using System;
using Microsoft.AspNetCore.Mvc;
using ems.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace ems.Controllers;

    [Log]
    public class AdminController : Controller
    {
        private readonly AdminDbContext admindb;
        
         public AdminController(AdminDbContext database)
        {
        admindb = database;
        }
        public IActionResult Privacy()
        {
            return View();
        }
    
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Options()
        {
          return View();
        }
        public IActionResult Index()
        {
            Repository repository=new Repository();
            List<Employee> List = repository.DisplayDetails();
            return View(List); 
        }

        [HttpGet]
         public IActionResult Registration()
         {
             return View(); 
         }
         [HttpPost]
         public IActionResult Registration(Employee employee)
         {
            Repository repository=new Repository();
            bool temp=repository.IsValidUser(employee.EmployeeID);
            bool temp1=repository.IsValidMail(employee.Email);
            bool temp2=repository.IsValidNumber(employee.MobileNumber);
            bool temp3=repository.IsValidAccount(employee.AccountNo);              
            if(temp){
                if(temp1){
                    if(temp2){
                        if(temp3){
                            repository.CreateEmployee(employee);
                            return View("thanks", employee);}
                        else{
                            ViewBag.AccountExist="Account already exist";
                            return View();}
                        }
                    else{
                    ViewBag.NumberExist="Number already Exist";
                    return View();}
                    }
                else{
                    ViewBag.EmailExist="Mail ID already exist";
                    return View();}
            }            
            else{
                ViewBag.IdExist ="ID already Exist";
                return View();}
         }
       
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int EmployeeID)
        {
            Repository repository=new Repository();
            bool temp=repository.IsValidId(EmployeeID);
            if(temp){
            repository.DeleteEmployee(EmployeeID);
            return RedirectToAction("Index");}
            else{
                ViewBag.InvalidIDmessage="Invalid ID";
                return View();}
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }   
        [HttpPost]
        public IActionResult Search(int EmployeeID)
        {
            Repository repository=new Repository();
            bool temp=repository.IsValidId(EmployeeID);
            if(temp){
            Employee employee=repository.SearchEmployee(EmployeeID);
            return View("SearchResult",employee);}
            else{
                ViewBag.InvalidIDmessage="Invalid ID";
                return View();}    
        } 

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }   
        [HttpPost]
        public IActionResult Update(int EmployeeID)
        {
            Repository repository=new Repository();
            bool temp=repository.IsValidId(EmployeeID);
            if(temp){
               Employee employee = repository.SearchEmployee(EmployeeID);
                return RedirectToAction("UpdateResults",employee);}
            else{
                ViewBag.InvalidIDmessage="Invalid ID";
                return View();}
           
        } 
        
        [HttpGet]
        public IActionResult UpdateResults(Employee employee)
        {
            return View(employee);
        }
        [HttpPost]
        public IActionResult UpdateResult(Employee employee)
        {
            Repository repository=new Repository();
            repository.UpdateEmployee(employee);
            return RedirectToAction("Index");      
        }

        [HttpGet]
        public IActionResult Task()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Task(TaskBase taskBase)
        {
            if(taskBase.Task == null || taskBase.DeadLine == null)
            {
                ViewBag.EmptyFieldMessage="Please fill the feilds before Submitting";
                return View();
            }
            
            else{
                try
                    {
                        admindb.TaskBase.Add(taskBase);
                        admindb.SaveChanges();
                        IEnumerable<TaskBase> task = admindb.TaskBase;
                        return View("TaskResult",task);
                    }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    ViewBag.TaskExistMessage="Task Already Exists";
                    return View();
                }
            
            }      
        }
        public IActionResult TaskResult()
        {
            IEnumerable<TaskBase> task = admindb.TaskBase;  
            return View(task); 
        }
        public IActionResult Mail()
        {
        return View();
        }
        public IActionResult DeleteTask(string task)
        {
            Repository repository=new Repository();
            repository.DeleteItem(task);
            IEnumerable<TaskBase>  Task = admindb.TaskBase;               
            return RedirectToAction("TaskResult",Task);
        }

        
       
    }    


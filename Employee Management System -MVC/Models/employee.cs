using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ems.Models
{
    public class Employee
    {
        public int EmployeeID{get; set;}
        public string? EmployeeName{get; set;}
        public int Age{get; set;}
        public decimal Salary{get; set;}
        public string? Department {get; set;}
        public string? Email{get;set;}
        public string? Name{get; set;}
        public string? Password{get;set;}
        public string? UserId{get;set;}
        public string? ConfirmPassword{get; set;}
        public string? Task{get; set;}
        public string? DeadLine{get; set;}
        public string? MobileNumber{get;set;}
        public string? Nationality{get;set;}
        public string? State{get;set;}
        public string? DateOfBirth{get;set;}
        public string? Gender{get;set;}
        public string? AccountNo{get;set;}
        public string? ProfilePIC{get;set;}
    }
}
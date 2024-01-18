using System.ComponentModel.DataAnnotations;
namespace Task.Models
{
    public class Signin
    {
        [Key]
        public string ?EmployeeId{get;set;}
         
         public string ?EmployeeName{get;set;}
         public string ?Role{get;set;}
         public string ?Password{get;set;}

    }
}
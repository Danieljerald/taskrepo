using System;
namespace Task.Models
{
   public class Database:IDatabase
   {
     public List<Register> userlist;
     public Database ()
     {
        userlist=new List<Register>();
     }
     public void AddRegister(Register register)
     {
     userlist.Add(register);
     }
     public IEnumerable<Register> GetRegister()
     {
        return userlist;
     }
   }
}
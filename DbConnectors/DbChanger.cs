using Microsoft.AspNetCore.Http;
using RandomItemsShop.DBEntity;
using RandomItemsShop.Models;
using System.Data.SqlClient;
using System.Net.NetworkInformation;




namespace RandomItemsShop.DbConnectors
{
    public class DbChanger
    {
        public async Task<string> InsertUser(UsersTable user)
        {

            try
            {
                using (UsersDBContext db = new UsersDBContext())
                {
                    int userInDb = db.usersTable.Where(p => p.Email == user.Email).Count();
                    if (userInDb == 0) { 
                    await db.usersTable.AddAsync(user);
                        db.SaveChanges();
                        return "Sign up successfull!";
                    }
                    return "User already exists";
                }
                
               }
            catch (SqlException ex)
            {
                return $"User already exists. Error #{ex.Errors[0].Number}";
            }
        }


    }
}



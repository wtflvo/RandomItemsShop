
using RandomItemsShop.Models;

using System.Data;

using System.Data.SqlClient;

using RandomItemsShop.DBEntity;



namespace RandomItemsShop.DbConnectors
{
    public class DbReader
    {
        public List<UsersTable> checkUserInDB(LoggedUser user)
        {
            try {

                using (UsersDBContext db = new UsersDBContext())
                {

                    return db.usersTable.Where(p => (p.Email == user.email) && (p.Password == user.password)).ToList();
                }     
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public dynamic getItemsFromDB(RequestData req)
        {
            try
            {
                using (UsersDBContext db = new UsersDBContext())
                {
                    if (req.title != null)
                    {
                        return db.ShopTable.Where(p => (p.Title.ToLower().Contains(req.title.ToLower())) && ((p.Category == req.category) || (req.category == "all"))).OrderBy(p => p.Id).Skip(req.page).Take(6).ToList();

                    }
                    return db.ShopTable.Where(p => req.category == "all" || p.Category == req.category).OrderBy(p => p.Id).Skip(req.page).Take(6).ToList();

                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);

            }

        }
        public int getCountFromDB(RequestData req)
        {
            using (UsersDBContext db = new UsersDBContext())
            {
                if (req.title != null)
                {
                    int count = db.ShopTable.Where(p => (p.Title.ToLower().Contains(req.title.ToLower()) && ((p.Category == req.category) || (req.category == "all")))).Count();
                    return count;
                }
                return db.ShopTable.Where(p => req.category == "all" || p.Category == req.category).Count();
            }
        }

    }
}







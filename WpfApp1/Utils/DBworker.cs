using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.SqlClient;
using WpfApp1.Database;
using System.Data.Entity.Migrations;

namespace WpfApp1.Utils
{
    internal class DBworker
    {

        static public int Check_login(string login, string password)
        {
            var user_id = -1;
            using (var context = new TradeEntities1())
            {
                var data = context.User.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
                if (data != null)
                {
                    user_id = data.Id;
                }
            }
            return user_id;

        }

 



        static public List<Database.Product> Select_Items(int price_order_type, string categvalue, string namelike)
        {
            List<Database.Product> result = new List<Database.Product>();

            List<string> to_select = new List<string>();

            using (var context = new TradeEntities1())
            {
                IQueryable<Database.Product> query = context.Product;

                // Цена
                if (price_order_type != 0)
                {
                    if (price_order_type == 1)
                    {
                        query = query.OrderByDescending(p => p.Cost);
                    }
                    else
                    {
                        query = query.OrderBy(p => p.Cost);
                    }
                }
                // Категория
                if (categvalue != "Выкл" && categvalue != null)
                {
                    query = query.Where(p => p.Category == categvalue);
                }

                // По названию и описанию
                if (namelike.Length > 2)
                {
                    query = query.Where(p => SqlFunctions.PatIndex("%" + namelike.Replace(" ", "%") + "%", p.Name) > 0 || SqlFunctions.PatIndex("%" + namelike.Replace(" ", "%") + "%", p.Description) > 0);
                }
                
                
                
                
                
                result = query.ToList();
            }
            return result;


        }

        static public List<string> get_categs_name()
        {
            List<string> result = new List<string>();
            using (var context = new TradeEntities1())
            {
                var data = context.Product.Select(p => p.Category).Distinct().ToList();
                result = data.ToList();
            }
            return result;
        }

        static public void delete_by_article(string articleid)
        {
            // Not works
            return;
            using (var context = new TradeEntities1())
            {
                var el = context.Product.Where(p => p.ArticleNumber == articleid).FirstOrDefault();
                if (el != null)
                {
                    context.Product.Remove(el);
                    context.SaveChanges();
                }
            }
        }

        static public void update_item(Database.Product product)
        {
            using (var context = new TradeEntities1())
            {
                context.Product.AddOrUpdate(p => p.id, product);
                context.SaveChanges();
            }
        }

        static public int get_role_id_by_user(int user_id)
        {
            int result = -1;
            using (var context = new TradeEntities1())
            {
                result = context.User.Where(u => u.Id == user_id).FirstOrDefault().RoleId;

            }
            return result;
        }
        static public Database.Product get_product_by_id(int id)
        {  
            Database.Product product = null;

            using (var context = new TradeEntities1())
            {
                product = context.Product.Where(p => p.id == id).FirstOrDefault();
             
            }

            return product;
        }
    }
}

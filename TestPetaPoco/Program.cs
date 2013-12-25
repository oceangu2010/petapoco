using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestPetaPoco.TestCase;
using System.Data.SqlClient;
using System.Data;
using PetaPoco;
using TestPetapoco;

namespace TestPetaPoco
{
    class Program
    {
        static void Main(string[] args)
        {
            ///PetaCoco灵活多变
            var db = new PetaPoco.Database("DefaultConnection");

            // 查询所有数据    
            foreach (var a in db.Query<Customers>("SELECT code, address,pkid,description FROM Customers"))
            {
                Console.WriteLine("{0} - {1}", a.Address, a.DataPrefix);
            }

            var c = db.SingleOrDefault<Customers>("select * from customers where code = @0", "naox");
            Console.WriteLine("Customer Code:" + c.Code+",Description:"+c.Description);

            //模糊匹配
            foreach(var a in db.Query<Customers>("select * from customers where code like @0", "%c%"))
               Console.WriteLine("Customer Code:" + a.Code + ",Description:" + a.Description);

            //多表关联
            //var b = db.SingleOrDefault<CustomerUsers>("select b.* from customers as a with(nolock) left join CustomerUsers as b with(nolock) on a.pkid =  b.customerId where a.pkid=@0",5);
            //Console.WriteLine("loginId:" + b.UserName + ",email:" + b.EmailAddress);
            //多表关联需要定义对义的实体类型
            var b = db.Fetch<TestPetaPoco.TestCase.CustomerUser>(PetaPoco.Sql.Builder.Append("select a.Code,a.Description,b.UserName from customers as a with(nolock) left join CustomerUsers as b with(nolock) on a.pkid =  b.customerId where a.pkid=5"));
           
            //多参数SQL查询
            var sql = Sql.Builder.Append("Select * from CustomerUsers ");
            //sql.Append(" where CreatedDt >= @0","2012-10-11");
            //sql.Append(" and CreatedDt <= @0", "2013-10-01");
            sql.Append(" where CreatedDt between @0 ", "2012-10-11");
            sql.Append(" and  @0 ", "2013-10-01");
            var customerUser = db.Query<CustomerUsers>(sql);
            foreach (var a in customerUser)
                Console.WriteLine("LoginId:"+a.UserName+",Email:"+a.EmailAddress+",CreateDt:"+a.CreatedDt.ToString("yyyy-MM-dd"));

            //insert data
            
            var menu = new CustomerUserMenusRelation();
            menu.CustomerId = 100;
            menu.MenuId = 100;
            //db.Insert(menu);
            db.Delete(menu);

            var addSql=Sql.Builder.Append("Insert into CustomerUserMenusRelation(customerId,menuId) ");
            addSql.Append(" values(@0,",200);
            addSql.Append("@0)",200);
            //db.Execute(addSql);

            //update message
            var customer = db.SingleOrDefault<Customers>("SELECT * FROM customers WHERE pkid=@0", 5);
            // Change it
            customer.Description = "PetaPoco was here again";
            db.Update("customers", "pkid", customer);
            //db.Update(customer);

            sql.LeftJoin("Customers as c with(nolock)");
            //PetaPoco.Sql.SqlJoinClause join = new Sql.SqlJoinClause();
            //join.On(

            var query = PetaPoco.Sql.Builder
            .Select("*")
            .From("CustomerUsers")
            .Where("CreatedDt < @0", DateTime.UtcNow)
            .OrderBy("CreatedDt DESC");
            //var resultCustomer = db.Query<Customers>(query);
            foreach (var a in db.Query<CustomerUsers>(query))
                Console.WriteLine("UserName:" + a.UserName + ",Email:" + a.EmailAddress + ",CreateDt:" + a.CreatedDt.ToString("yyyy-MM-dd"));
            Console.WriteLine("It's OK.");

            Console.ReadKey();
        }
    }
}

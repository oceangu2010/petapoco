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


            //db.Update("", "", new { UserName = "" }, 123);

            //5、直接执行sql
            //db.Execute("DELETE FROM articles WHERE draft<>0");
            //6、调用存储过程
            ////调用存储过程
            //db.Execute("exec procSomeHandler @0, @1", 3, "2011-10-01");
            //调用带输出(OUTPUT)参数的存储过程, 写的sql语句，@0参数后的“output”是关键
            //var param = new SqlParameter() { Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Int };
            //db.Execute("exec procSomeHandler @0 OUTPUT", param);


            //2、分页
            //// 分页实质在内部是用Row_Number()重写了sql，支持join
            //var result=db.Page(1, 20, "SELECT * FROM articles WHERE category=@0 ORDER BY date_created DESC", "coolstuff");
            //上面的分页sql，会被改写为sql：

            //SELECT * FROM (
            //    SELECT ROW_NUMBER() OVER (ORDER BY date_created DESC) peta_rn, * FROM articles WHERE category=@0 ) peta_paged
            //WHERE peta_rn>@1 AND peta_rn

            //7、代替返回值DataTable 有时，我们并不想每条执行的sql都需要创建对应的实体类，这样会导致项目中存在过多的实体类，有方法能做到DataTable这样灵活就最好了。在.net4.0中，PetaPoco可以返回dynamic类型，可以很好地解决这个问题，而在.net3.5中就没办法，不过可以通过修改PetaPoco代码，实现使用Dictionary类型来代替dynamic动态类型的功能。改动代码如下：https://github.com/cxfksword/PetaPoco/commit/e07746c06977f09ef8e7a0f81b718e520b4513ed
            //var list = db.Fetch>("select article_id,date_created from articles");
            //使用petapoco时有点需要注意，就是当数据库字段数据类型是varchar等非unicode字符类型时，petapoco传参需要把string转换为AnsiString类型，否则会有性能问题。
            //Ansi String Support
            //DBA guru Rob Sullivan yesterday pointed out that SQL Server has pretty severe performance overhead if you try to query an index with varchar column using a unicode string parameter. To fix this the parameter needs to be bound as DbType.AnsiString. To facilitate this you can now wrap such string parameters in a new AnsiString class:
            //var a = db.SingleOrDefault("WHERE title=@0", new PetaPoco.AnsiString("blah"));

            //8,支持简单事务 事务另外一种方法 可以利用存储过程事务来解决
            //using (var scope=db.Transaction)
            //{
            //    // Do transacted updates here
            //    // Commit
            //    scope.Complete();
            //}

            //// Is this a new record  检查对象是否已经存在
            //if (db.IsNew(a))
            //{
            //    // Yes it is...
            //}
           

            //9，删除有2种方法：
            //// Delete an article extracting the primary key from a record
            //db.Delete("articles", "article_id", a);
            //// Or if you already have the ID elsewhere
            //db.Delete("articles", "article_id", null, 123);

            //1.12. 自动Select子句
            //使用PetaPoco时，大多数查询以”select * from table”开始。可以省略掉SELECT * FROM table子句，因为petapoco会自动帮我们构建。

            //例如下句：

            // // Get a record
            //var a=db.SingleOrDefault<article>("SELECT * FROM articles WHERE article_id=@0", 123);
 

            //可简写为：

            // // Get a record
            //var a=db.SingleOrDefault<article>("WHERE article_id=@0", 123);

            Console.ReadKey();
        }
    }
}

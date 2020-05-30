using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

/*
 * 连接数据库过程中遇到的一些坑：
 * 首先nuget的默认包管理方式要是packages.config。
 * 否则安装实体框架包后，不会自动修改app.config。
 * 
 * 其次，MySQL服务器的版本必须和安装的实体框架包的版本一致，否则会连接不上。
 */
namespace OrderManagementDB
{
    class OrderContext : DbContext
    {

        public OrderContext() : base("OrderDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

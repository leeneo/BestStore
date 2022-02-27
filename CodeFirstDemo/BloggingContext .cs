using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo
{
    public class BloggingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Visual Studio 2015 | 使用Visual Studio创建的LocalDb 12 实例
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CodeFirstDB;Trusted_Connection=True;ConnectRetryCount=0");

            // Visual Studio 2013 | 使用Visual Studio创建的LocalDb 11 实例
            // optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=CodeFirstDB;Trusted_Connection=True;");

            // Visual Studio 2012 | 使用Visual Studio创建的SQL Express实例
            // optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CodeFirstDB;Trusted_Connection=True;");

            // 在SQLServer 上创建实例的连接字符串方式
            //optionsBuilder.UseSqlServer(@"Server=.;Database=CodeFirstDB;User ID=neo;Password=123;Trusted_Connection=True;ConnectRetryCount=0");
            //optionsBuilder.UseSqlServer(@"Server=.;Database=CodeFirstDB;uid=neo;pwd=123;Trusted_Connection=True;ConnectRetryCount=0");
            //optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=CodeFirstDB;User Id=neo;Password=123;");

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>().HasKey(b => b.BlogId);
            builder.Entity<Blog>().Property(b => b.Url).IsRequired(true);
        }


    }
}
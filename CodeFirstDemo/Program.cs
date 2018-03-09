using CodeFirstDemo.Repositoies;
using System;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    class Program
    {
        /* 异步函数的执行方式：
        *  1，await x.ExecAsync()（将所在函数声明为async）
        *  2，x.ExecAsync().Wait()
        */
        //static async void MainAsync()
        //{
        //    using (var db = new BloggingContext())
        //    {
        //        BlogRepository br = new BlogRepository(db);
        //        int x = await br.AddAsync(new Blog { Url = "www.leeneo.com" });
        //        Console.WriteLine(x);
        //        Console.WriteLine();
        //        Console.WriteLine("All blogs in database:");
        //        foreach (var blog in db.Blogs)
        //        {
        //            Console.WriteLine(" - {0}", blog.Url);
        //        }
        //    }
        //}
        static void Main(string[] args)
        {
            //MainAsync();
            using (var db = new BloggingContext())
            {
                SampleDataInitializer sampleData = new SampleDataInitializer(db);
                sampleData.LoadSampleDataAsync().Wait();
                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
                Console.ReadKey();
            }
        }
    }
}

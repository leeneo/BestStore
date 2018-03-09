using CodeFirstDemo.Repositoies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    public class SampleDataInitializer
    {
        private BloggingContext _dbContext = null;

        public SampleDataInitializer(BloggingContext context)
        {
            _dbContext = context;
        }

        public async Task LoadSampleDataAsync()
        {
            // Add Blogs
            BlogRepository blogRepository = new BlogRepository(_dbContext);
            int x=await blogRepository.AddAsync(new Blog { Url = "www.leeneo.cn" });
            Console.WriteLine("ID为 "+x+" 的 blog 已添加");
            
            //_dbContext.Blogs.AddRange(new Blog[] {
            //    new Blog{Url="http://xx.com/3"},
            //    new Blog{Url="https://xx.com/4"}
            //});

            // Add Posts
            _dbContext.Posts.Add(new Post
            {
                BlogId = 2,
                Content = "fwoiwerwr",
                Title = "jjj"
            });

            // Submit data into Database
            await _dbContext.SaveChangesAsync();

        }
    }
}
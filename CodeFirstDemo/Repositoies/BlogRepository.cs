using CodeFirstDemo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Repositoies
{
    public class BlogRepository : IBlogRepository
    {
        private BloggingContext _dbContext = null;
        public BlogRepository(BloggingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Blog blog)
        {
            if (null == blog)
                return -1;
            _dbContext.Blogs.Add(blog);
            await _dbContext.SaveChangesAsync();
            return blog.BlogId;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task DeleteAsync(int blogid)
        {
            var blog = await _dbContext.Blogs.SingleOrDefaultAsync(b => b.BlogId == blogid);
            if (blog != null)
            {
                _dbContext.Blogs.Remove(blog);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Blog> GetAsync(int blogid)
        {
            return await _dbContext.Blogs.Where(b => b.BlogId == blogid).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsAsync(int blogid,string filter, int pageSize, int pageCount)
        {
            var results = await _dbContext.Posts.Where
            (p => p.BlogId == blogid && (String.IsNullOrEmpty(filter) ||
            p.Title.Contains(filter) || p.Content.Contains(filter)))
            .Select(p => new { Post = p, })
            .Skip(pageSize * pageCount)
            .Take(pageSize)
            .ToListAsync();

            return results.Select(p => p.Post);
        }

        public async Task UpdateAsync(Blog bl)
        {
            if (null == bl)
                return;
            _dbContext.Blogs.Update(bl);
            await _dbContext.SaveChangesAsync(); 
        }

    }
}

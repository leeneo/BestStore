using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Interfaces
{    
    // 定义IProductRepository 商品接口;后面会由ProductRepository对象来继承;
    public interface IBlogRepository
    {
        // 异步方式获取全部Blog，并保存到List<>泛型集合
        Task<List<Blog>> GetAllAsync();

        // 异步方式向数据源添加一个Blog业务实体信息
        Task<int> AddAsync(Blog bl);

        // 根据给定的BlogID, 异步方式从数据源中删除指定商品的信息
        Task DeleteAsync(int BlogID);

        // 根据给定的商品ID, 异步方式从数据源中提取业务实体
        Task<Blog> GetAsync(int BlogID);

        // 根据给定的条件和分页设定，返回符合条件的Blog业务实体
        Task<IEnumerable<Post>> GetPostsAsync(int blogid,string filter, int pagesize, int pagecount);

        // 异步方式更新指定的商品业务实体信息
        Task UpdateAsync(Blog bl);
    }
}

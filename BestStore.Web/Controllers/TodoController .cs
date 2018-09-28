using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BestStore.Models;
using BestStore.Data.Interfaces;
using System.Collections.Generic;

namespace BestStore.Web.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        //依赖注入的在MVC中的使用方式目前有三种，分别是Controller的构造函数、属性以及View中的Inject形式
        //其中构造函数注入和之前的MVC中的是一样的，示例代码如下

        // 依赖注入框架会自动找到ITodoRepository实现类的示例，赋值给该构造函数
        private readonly ITodoRepository _repository;
        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // 依赖注入框架会自动找到ITodoRepository实现类的示例，赋值给该属性
        //[FromServices]
        //public ITodoRepository Repository { get; set; }

        //在视图中，则可以通过 @inject关键字来实现注入类型的实例提取，示例如下：
        //@using WebApplication1
        //@inject ITodoRepository repository
        //<div>
        //    @repository.AllItems.Count()
        //</div>

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _repository.AllItems;  //这里就可以使用该对象了
        }
    }
}

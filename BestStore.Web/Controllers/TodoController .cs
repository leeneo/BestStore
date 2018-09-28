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
        //����ע�����MVC�е�ʹ�÷�ʽĿǰ�����֣��ֱ���Controller�Ĺ��캯���������Լ�View�е�Inject��ʽ
        //���й��캯��ע���֮ǰ��MVC�е���һ���ģ�ʾ����������

        // ����ע���ܻ��Զ��ҵ�ITodoRepositoryʵ�����ʾ������ֵ���ù��캯��
        private readonly ITodoRepository _repository;
        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // ����ע���ܻ��Զ��ҵ�ITodoRepositoryʵ�����ʾ������ֵ��������
        //[FromServices]
        //public ITodoRepository Repository { get; set; }

        //����ͼ�У������ͨ�� @inject�ؼ�����ʵ��ע�����͵�ʵ����ȡ��ʾ�����£�
        //@using WebApplication1
        //@inject ITodoRepository repository
        //<div>
        //    @repository.AllItems.Count()
        //</div>

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _repository.AllItems;  //����Ϳ���ʹ�øö�����
        }
    }
}

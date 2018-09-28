using System.Collections.Generic;
using BestStore.Models;

namespace BestStore.Data.Interfaces
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> AllItems { get; }
        void Add(TodoItem item);
        TodoItem GetById(int id);
        bool TryDelete(int id);
    }
}

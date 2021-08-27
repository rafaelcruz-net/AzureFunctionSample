using Infra.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repository
{
    public class TodoItemRepository
    {
        public static List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();

        public List<TodoItem> GetAll() => TodoItems;

        public TodoItem GetById(Guid id) => TodoItems.FirstOrDefault(x => x.Id == id);

        public void Save(TodoItem item)
        {
            TodoItems.Add(item);
        }

    }
}

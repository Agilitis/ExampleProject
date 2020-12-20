using ExampleProject.Application.Common.Mappings;
using ExampleProject.Domain.Entities;

namespace ExampleProject.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}

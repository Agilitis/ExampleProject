using ExampleProject.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace ExampleProject.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}

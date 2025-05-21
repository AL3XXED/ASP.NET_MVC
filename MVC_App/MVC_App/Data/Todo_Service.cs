using MVC_App.Models;

namespace MVC_App.Data;

public class Todo_Service
{
    private List<_Todos_> todos;

    public Todo_Service()
    {
        todos = new List<_Todos_>
        {
            new _Todos_ { Id = 1, Name = "Kaffee Kochen" },
            new _Todos_ { Id = 2, Name = "Zimmer aufräumen" },
            new _Todos_ { Id = 3, Name = "Geschirr spülen" }
        };
    }

    //READ
    public List<_Todos_> GetAllTodos() => todos;
    public _Todos_ GetTodoById(int id) => todos.FirstOrDefault(t => t.Id == id);


    //CREATE
    public void AddTodo(_Todos_ newTodo)
    {
        newTodo.Id = todos.Any() ? todos.Max(t => t.Id) + 1 : 1;
        todos.Add(newTodo);
    }
    //UPDATE

    //DELETE
}

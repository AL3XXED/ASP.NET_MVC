using RESTApi.Models;

namespace RESTApi.Services;

public static class TodoService
{
    public static List<Todo> Todos = new List<Todo>()
    {
        new Todo(){ Id = 1, Name = "Kaffee Kochen" },
        new Todo(){ Id = 2, Name = "Zimmer aufräumen" },
        new Todo(){ Id = 3, Name = "Geschirr spülen" }
    };

    //statischer Konstruktor
    static TodoService()
    {
        for (int i = 4; i < 26; i++)
        {
            Todos.Add(new Todo() { Id = i, Name = $"Aufgabe{i}"});
        }
    }
}

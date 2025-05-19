

using REST_Client;
using System.Net.Http.Json;

var client = new HttpClient();
client.DefaultRequestHeaders.Add("X-Client-Name", "C#-App");
//Create
var postResponse = await client.PostAsJsonAsync("http://localhost:5178/items", new Todo_ { Name = "C# -Code Schreiben" });
// ...

//READ
int todoId = 1;
// READ Detail
do
{
    await GetTodo(todoId++);
} while (todoId < 5);

// Update
// 1) Schlage die zu veränderne Ressource auf dem Server nach
int todoEditId = 2;
var todoEdit = await GetTodo(todoEditId);
todoEdit.Name = "Ressource durch C# aktualisiert";
var putResponse = await client.PutAsJsonAsync($"http://localhost:5178/items/{todoEditId}", todoEdit);

if (putResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
{
    //Ausgabe...
}
else if (putResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
{

}
else if (putResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
{

}

//Delete
int todoDeleteId = 3;
var deleteResponse = await client.DeleteAsync($"http://localhost:5178/items/{todoDeleteId}");
Console.ForegroundColor = ConsoleColor.Red;
switch (deleteResponse.StatusCode)
{
    case System.Net.HttpStatusCode.NotFound:
        Console.WriteLine("Ressource konnte nicht gelöscht werden, weil nicht gefunden");
        break;
    case System.Net.HttpStatusCode.NoContent:
        Console.WriteLine($"Ressource (mit Id {todoDeleteId}) erfolgreich gelöscht");
        break;
}
Console.ResetColor();

//READ List
var response2 = await client.GetAsync($"http://localhost:5178/items");
if (response2.IsSuccessStatusCode)
{
    var list = await response2.Content.ReadFromJsonAsync<List<Todo_>>();
    if (list is not null)
    {
        Console.WriteLine("Alle Todos");
        foreach (var item in list)
        {
            Console.WriteLine("\t" + item.Name);
        }
    }
}




Console.WriteLine("Taste drücken um Programm zu beenden");
Console.ReadKey();

 async Task<Todo_> GetTodo(int id)
{
    var response = await client.GetAsync($"http://localhost:5178/items/{id}");
    Console.WriteLine($"******Statuscode: {response.StatusCode} : {(int)response.StatusCode}**********");

    if (response.IsSuccessStatusCode)
    {
        var item = await response.Content.ReadFromJsonAsync<Todo_>();
        if (item != null)
        {
            Console.WriteLine($"{item.Id}: {item.Name}");
            return item;
        }

    }
    else
    {

        Console.WriteLine($"Kein Todo mit Id {id} gefunden");
    }
    Console.WriteLine(new String('*', 20));
    return null;
}
using Microsoft.AspNetCore.Http.HttpResults;
using RESTApi.Models;
using RESTApi.Services;

var builder = WebApplication.CreateBuilder(args);

const string policy = "CORS-Policy";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy,
                     policy =>
                     {
                         policy.AllowAnyOrigin() 
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(policy);

app.UseHttpsRedirection();



//Crud - Operationen

// Create
app.MapPost("/items", (Todo item /*, HttpRequest request*/) =>
{
    ////Client erfragen
    /*
    var clientName = request.Headers["X-Client-Name"].FirstOrDefault();
    var user_agent = request.Headers["User-Agent"].FirstOrDefault();
    */

    //serverseitiges Validieren
    if (!String.IsNullOrEmpty(item.Name))
    {
        //Id-Vergabe
        item.Id = TodoService.Todos.Max(t => t.Id) + 1;
        TodoService.Todos.Add(item);
        return Results.Created($"/items/{item.Id}", item);
    }
    return Results.BadRequest();
});

//Read 

//Read a)  -List
app.MapGet("/items", (int seite = 1, int seitengroesse = 5) =>
{
    //Paginierungslogik mithilfe von Querystrings

    // .../items?seite=1&seitengroesse=3
    //if (!seite.HasValue || !seitengroesse.HasValue ) //HasValue ist Prop von nullable von int => int? seite
    //{
    //    return Results.Ok(TodoService.Todos);
    //}

    //wende die Paginierungslogik mit LINQ
    var abschnittTodos = TodoService.Todos
                         .Skip((seite - 1) * seitengroesse)
                         .Take(seitengroesse)
                         .ToList();
    return Results.Ok(abschnittTodos);
    //versende optional Meta-Information mit
    //var ergebnis = new { Seite = seite, Seitengroesse = seitengroesse, Todos = abschnittTodos };
    //return Results.Ok(ergebnis);
});
// Read b) Detailogik
app.MapGet("/items/{id}", (int id) =>
{
    var todo = TodoService.Todos.FirstOrDefault( t => t.Id == id);
    if (todo == null)  // Ressource wurde nicht gefunden
    {
        return Results.NotFound();
    }
    return Results.Ok(todo); //Versende die Ressource
});
//Update
app.MapPut("/items/{id}", (int id, Todo item) =>
{
    var todo = TodoService.Todos.FirstOrDefault(t => t.Id == id);
    if (todo == null)  // Ressource wurde nicht gefunden
    {
        return Results.NotFound();
    }

    //serverseitge Validierung
    if (!String.IsNullOrEmpty(item.Name))
    {
        //Ressource manipulieren...
        todo.Name = item.Name;
        return Results.NoContent();
    }
    return Results.BadRequest();
});

//delete
app.MapDelete("/items/{id}", (int id) =>
{
    //gibts die Ressource?
    var todo = TodoService.Todos.FirstOrDefault(t => t.Id == id);
    if (todo == null)  // Ressource wurde nicht gefunden
    {
        return Results.NotFound();
    }
    //lösche die Ressource
    TodoService.Todos.Remove(todo);
    return Results.NoContent();
});


app.Run();




namespace Todo.Common.Classes;

public class Todos
{
    List<Todo> todos = new();

    public List<Todo> Get() => todos;
    public void Add(string description) => todos.Add(new Todo(description));
    public void Remove(Todo todo) => todos.Remove(todo);
}

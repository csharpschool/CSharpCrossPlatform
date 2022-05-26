namespace Todo.Tests;

public class TodosTest
{
    [Fact]
    public void CanCreateTodosInstance()
    {
        var todos = new Todos();

        Assert.NotNull(todos);
    }

    
    [Fact]
    public void CanAddAndGetTodos()
    {
        var todos = new Todos();
        todos.Add("todo 1");

        var todo = todos.Get().FirstOrDefault();
        
        Assert.NotNull(todo);
        Assert.NotEmpty(todos.Get());
        Assert.Empty(todo?.GetDescriptionAttributes());
    }

    [Fact]
    public void CanRemoveTodos()
    {
        var todos = new Todos();
        todos.Add("To-do 1");
        var countBeforeDelete = todos.Get().Count;
        var todo = todos.Get().FirstOrDefault();
        todos.Remove(todo);

        Assert.Equal(1, countBeforeDelete);
        Assert.Empty(todos.Get());
    }
}
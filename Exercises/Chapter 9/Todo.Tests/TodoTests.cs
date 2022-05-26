using T = Todo.Common.Classes;
namespace Todo.Tests;

public class TodoTest
{
    [Fact]
    public void CanCreateTodoInstance()
    {
        var todo = new T.Todo("Todo 1");

        Assert.NotNull(todo);
    }

    [Fact]
    public void CanReadDescriptionAndCollectionsAreEmpty()
    {
        var todo = new T.Todo("Todo 1");

        Assert.Equal("Todo 1", todo.GetDescription());
        Assert.Empty(todo.GetCheckboxAttributes());
        Assert.Empty(todo.GetDescriptionAttributes());
    }

    [Fact]
    public void CollectionsHaveValues()
    {
        var todo = new T.Todo("Todo 1");
        todo.CheckAttributes();
        Assert.NotEmpty(todo.GetCheckboxAttributes());
        Assert.NotEmpty(todo.GetDescriptionAttributes());
    }
}
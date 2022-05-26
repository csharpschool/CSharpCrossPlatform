namespace Todo.Common.Classes;

public class Todo
{
    private string description = string.Empty;
    private bool completed = false;
    private Dictionary<string, object> checkboxAttributes = new();
    private Dictionary<string, object> descriptionAttributes = new();

    public Todo(string description) => this.description = description;
    
    public string GetDescription() => description;
    public Dictionary<string, object> GetCheckboxAttributes() => checkboxAttributes;
    public Dictionary<string, object> GetDescriptionAttributes() => descriptionAttributes;

    public void CheckAttributes()
    {
        completed = !completed;

        if (completed)
        {
            checkboxAttributes.Add("checked", "checked");
            descriptionAttributes.Add("class", "completed");
        }
        else
        {
            checkboxAttributes.Clear();
            descriptionAttributes.Clear();
        }
    }
}

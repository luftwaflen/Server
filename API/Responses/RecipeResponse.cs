namespace API.Responses;

public class RecipeResponse
{
    public RecipeResponse(Guid id, string text)
    {
        Id = id;
        Text = text;
    }
    public Guid Id { get; set; }
    public string Text { get; set; }
}
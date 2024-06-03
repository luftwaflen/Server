namespace Domain.Models;

public class Recipe
{
    public Recipe()
    {
        Id= Guid.NewGuid();
    }

    public Recipe(string text) : this()
    {
        Text = text;
    }

    public Guid Id { get; set; }
    public string Text { get; set; }
    public virtual RecipeRelation RecipeRelation { get; set; }
}
namespace Domain.Models;

public class Patient
{
    public Patient()
    {
        Id = Guid.NewGuid();
    }
    public Patient(string login, string password) : this()
    {
        User = new User(login, password);
        User.Role = UserRoles.Patient;
        Diary = new Diary(this);
        RecipeRelations = new List<RecipeRelation>();
        PersonalDoctor = null;
    }

    public Guid Id { get; set; }
    public virtual User User { get; set; }
    public virtual Diary Diary { get; set; }
    public virtual Doctor? PersonalDoctor { get; set; }
    public virtual List<RecipeRelation> RecipeRelations { get; set; }
}
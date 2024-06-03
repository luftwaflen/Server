namespace Domain.Models;

public class Doctor
{
    public Doctor()
    {
        Id = Guid.NewGuid();
    }
    public Doctor(string login, string password, string firstName, string secondName) : this()
    {
        User = new User(login, password);
        User.Role = UserRoles.Doctor;
        FirstName = firstName;
        SecondName = secondName;
        Patients = new List<Patient>();
        RecipeRelations = new List<RecipeRelation>();
    }

    public Guid Id { get; set; }
    public virtual User User { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public virtual List<Patient> Patients { get; set; }
    public virtual List<RecipeRelation> RecipeRelations { get; set; }
}
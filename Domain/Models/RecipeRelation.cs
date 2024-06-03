namespace Domain.Models;

public class RecipeRelation
{
    public RecipeRelation()
    {
        
    }
    public RecipeRelation(Guid patientId,
        Guid doctorId,
        Guid recipeId,
        Patient patient,
        Doctor doctor,
        Recipe recipe) : this()
    {
        PatientId = patientId;
        DoctorId = doctorId;
        RecipeId = recipeId;
        Patient = patient;
        Doctor = doctor;
        Recipe = recipe;
    }

    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid RecipeId { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual Recipe Recipe { get; set; }
}
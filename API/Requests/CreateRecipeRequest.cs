namespace API.Requests;

public class CreateRecipeRequest
{
    public string PatientId { get; set; }
    public string DoctorId { get; set; }
    public string Text { get; set; }
}
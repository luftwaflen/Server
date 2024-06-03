namespace API.Requests;

public class RegisterDoctorRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
}
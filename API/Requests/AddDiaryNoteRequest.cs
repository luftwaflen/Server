namespace API.Requests;

public class AddDiaryNoteRequest
{
    public string PatientId { get; set; }
    public string PressureSYS { get; set; }
    public string PressureDIA { get; set; }
    public string Pulse { get; set; }
    public string Description { get; set; }
}
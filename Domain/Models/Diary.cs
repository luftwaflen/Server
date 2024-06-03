namespace Domain.Models;

public class Diary
{
    public Diary()
    {
        Id = Guid.NewGuid();
        DiaryNotes = new List<DiaryNote>();
    }

    public Diary(Patient patient) : this()
    {
        Patient = patient;
        PatientId = patient.Id;
    }

    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual List<DiaryNote> DiaryNotes { get; set; }
}
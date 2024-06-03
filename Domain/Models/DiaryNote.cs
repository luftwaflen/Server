namespace Domain.Models;

public class DiaryNote
{
    public DiaryNote()
    {
        Id = Guid.NewGuid();
    }
    public DiaryNote(DateTime date,
        string pressureSys,
        string pressureDia,
        string pulse,
        string description)
        : this()
    {
        Id = Guid.NewGuid();
        Date = date;
        PressureSYS = pressureSys;
        PressureDIA = pressureDia;
        Pulse = pulse;
        Description = description;
    }

    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string PressureSYS { get; set; }
    public string PressureDIA { get; set; }
    public string Pulse { get; set; }
    public string Description { get; set; }
}
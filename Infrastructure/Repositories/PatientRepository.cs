using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<Patient> GetPatientByIdAsync(Guid id)
    {
        var patient = await _db.Patients.FirstOrDefaultAsync(u => u.Id == id);

        return patient;
    }
}
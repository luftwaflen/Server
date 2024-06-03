using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(DiaryDbContext context) : base(context)
    {
    }

    public async Task<Doctor> GetDoctorByIdAsync(Guid id)
    {
        var doctor = await _db.Doctors.FirstOrDefaultAsync(u => u.Id == id);

        return doctor;
    }
}
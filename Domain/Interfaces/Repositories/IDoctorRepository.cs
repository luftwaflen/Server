using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IDoctorRepository : IRepository<Doctor>
{
    Task<Doctor> GetDoctorByIdAsync(Guid id);
}
using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IPatientRepository : IRepository<Patient>
{
    Task<Patient> GetPatientByIdAsync(Guid id);
}
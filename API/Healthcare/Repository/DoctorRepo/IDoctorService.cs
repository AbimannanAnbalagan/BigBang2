using Healthcare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Repository.DoctorRepo
{
  public interface IDoctorService
  {
    Task<List<Doctor>> GetDoctors();
    Task<List<Doctor>> PostDoctors(Doctor doctor);
    Task<List<Doctor>> PutDoctor(int id, Doctor doctor);

  }
}

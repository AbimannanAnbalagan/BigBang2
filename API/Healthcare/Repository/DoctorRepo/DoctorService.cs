using Healthcare.Controllers;
using Healthcare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Repository.DoctorRepo
{
  public class DoctorService : IDoctorService
  {
    private readonly HealthCareContext _context;

    public DoctorService(HealthCareContext context)
    {
      _context = context;
    }

    public async Task<List<Doctor>> GetDoctors()
    {
      var result = await _context.Doctors.ToListAsync();
      if (result == null)
      {
        throw new Exception("No Doctors Found");
      }
      return result;
    }

    public async Task<List<Doctor>> PostDoctors(Doctor doctor)
    {
      await _context.Doctors.AddAsync(doctor);
      await _context.SaveChangesAsync();
      return _context.Doctors.Where(x=> x.UniqueId== doctor.UniqueId).ToList();

    }

    public async Task<List<Doctor>> PutDoctor (int id, Doctor doctor)
    {
      var result = await _context.Doctors.FindAsync(id);
      if (result == null)
      {
        throw new Exception("No Doctor in the given id");
      }
      result.Status = doctor.Status;
      await _context.SaveChangesAsync();
      return await _context.Doctors.Where(x => x.DoctorId == id).ToListAsync();
    }
  }
}

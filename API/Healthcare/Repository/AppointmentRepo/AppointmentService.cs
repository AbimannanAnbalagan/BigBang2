using Healthcare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Repository.AppointmentRepo
{
  public class AppointmentService : IAppointmentService
  {
    private readonly HealthCareContext _context;

    public AppointmentService(HealthCareContext context)
    {
      _context = context;
    }
    public async Task<List<Appointment>> GetAppointments()
    {
      var result = _context.Appointments.Where(x => x.Status == "booked").ToListAsync();
      if (result == null)
      {
        throw new Exception("No Appointments found");
      }
      return await result;
    }

    public async Task<List<Appointment>> PostAppointment(Appointment appointment)
    {
      await _context.Appointments.AddAsync(appointment);
      await _context.SaveChangesAsync();
      return await _context.Appointments.Where(x=>x.AppointmentId== appointment.AppointmentId).ToListAsync();
    }

    public async Task<List<Appointment>> PutAppointment(int id, Appointment appointment)
    {
      var result = await _context.Appointments.FindAsync(id);
      if (result == null)
      {
        throw new Exception("No Appointment in the mentioned id");
      }
      result.Status = appointment.Status;
      await _context.SaveChangesAsync();
      return await _context.Appointments.Where(x=>x.AppointmentId == id).ToListAsync();
    }

  }
}

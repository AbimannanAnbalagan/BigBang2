using Healthcare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Repository.AppointmentRepo
{
  public interface IAppointmentService
  {
    Task<List<Appointment>> GetAppointments();
    Task<List<Appointment>> PostAppointment(Appointment appointment);
    Task<List<Appointment>> PutAppointment(int id, Appointment appointment);

  }
}

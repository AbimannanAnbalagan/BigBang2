using API.Models;

namespace API.Repositories.Appointments
{
    public interface IAppointment
    {
        Task<List<Appointment>> GetAppointments(string name);
        Task<List<Appointment>> PostAppointment(Appointment appointment);
        Task<List<Appointment>> PutAppointment(int id, Appointment appointment);
    }
}

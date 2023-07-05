using API.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace API.Repositories.Appointments
{
    public class AppointmentService : IAppointment
    {
        private readonly BigBang2Context _context;

        public AppointmentService(BigBang2Context context)
        {
            _context = context;
        }
        public async Task<List<Appointment>> GetAppointments(string name)
        {

            var result = (from a in _context.Appointments
                               join d in _context.Doctors on a.DoctorId equals d.DoctorId
                               where d.Name == name
                               select a).ToListAsync();

            if (result == null)
            {
                throw new Exception("No apointments for you");
            }

            return await result;
        }

        public async Task<List<Appointment>> PostAppointment(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return await _context.Appointments.Where(x => x.AppointmentId == appointment.AppointmentId).ToListAsync();
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
            return await _context.Appointments.Where(x => x.AppointmentId == id).ToListAsync();
        }


    }
}

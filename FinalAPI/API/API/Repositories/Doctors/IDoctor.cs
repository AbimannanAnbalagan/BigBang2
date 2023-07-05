using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Doctors
{
    public interface IDoctor
    {
        Task<List<Doctor>> GetDoctors();
        Task<List<Doctor>> DoctorById(string name);
        Task<List<Doctor>> PostDoctors(Doctor doctor);
        Task<List<Doctor>> PutDoctor(string username, Doctor doctor);

    }
}

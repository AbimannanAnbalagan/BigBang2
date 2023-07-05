using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Doctors
{
    public class DoctorService : IDoctor
    {
        private readonly BigBang2Context _context;

        public DoctorService(BigBang2Context context)
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

        public async Task<List<Doctor>> DoctorById(string name)
        {
            var result = await _context.Doctors.Where(x=>x.Name==name).ToListAsync();
            if (result == null)
            {
                throw new Exception("No Results found");
            }

            return result;
        }

        public async Task<List<Doctor>> PostDoctors(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return _context.Doctors.Where(x => x.UserId == doctor.UserId).ToList();

        }

        public async Task<List<Doctor>> PutDoctor(string username, Doctor doctor)
        {
            var result = await _context.Doctors.FirstOrDefaultAsync(x => x.Name == username);
            if (result == null)
            {
                throw new Exception("No Doctor in the given id");
            }
            result.Specialist = doctor.Specialist;
            result.Address = doctor.Address;
            result.Mobilenum = doctor.Mobilenum;
            result.EmailId= doctor.EmailId;
            result.Designation = doctor.Designation;
            result.ImageUrl= doctor.ImageUrl;
            await _context.SaveChangesAsync();
            return await _context.Doctors.Where(x => x.Name == username).ToListAsync();
        }
    }
}


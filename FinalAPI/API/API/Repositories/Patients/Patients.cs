using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Patients
{
    public class Patients : IPatients
    {
        private readonly BigBang2Context _context;

        public Patients(BigBang2Context context)
        {
            _context = context;
        }

        public async Task<List<Patient>> getbyname(string name)
        {
            var result = await _context.Patients.Where(x=>x.PatientName== name).ToListAsync();
            if (result.Count() <1)
            {
                throw new Exception("No Doctors Found");
            }
            return result;
        }

    }
}

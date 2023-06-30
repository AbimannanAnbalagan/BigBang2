using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Healthcare.Models;
using Healthcare.Repository.DoctorRepo;

namespace Healthcare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _context;

        public DoctorsController(IDoctorService context)
        {
            _context = context;
        }

    [HttpGet]
    public async Task<ActionResult<List<Doctor>>> GetDoctors()
    {
      try
      {
        return await _context.GetDoctors();

      }
      catch (Exception ex)
      {
        return new BadRequestObjectResult(ex);
      }
    }

    [HttpPost]
    public async Task<ActionResult<List<Doctor>>> PostDoctors(Doctor doctor)
    {
      try
      {
        return await _context.PostDoctors(doctor);

      }
      catch (Exception ex)
      {
        return new BadRequestObjectResult(ex);
      }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<Doctor>>> PutDoctor(int id, Doctor doctor)
    {
      try
      {
        return await _context.PutDoctor(id ,doctor);

      }
      catch (Exception ex)
      {
        return new BadRequestObjectResult(ex);
      }
    }


      // GET: api/Doctors
    /*[HttpGet]
    public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
    {
      if (_context.Doctors == null)
      {
          return NotFound();
      }
        return await _context.Doctors.ToListAsync();
    }

    // GET: api/Doctors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> GetDoctor(int id)
    {
      if (_context.Doctors == null)
      {
          return NotFound();
      }
        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor == null)
        {
            return NotFound();
        }

        return doctor;
    }

    // PUT: api/Doctors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
    {
        if (id != doctor.DoctorId)
        {
            return BadRequest();
        }

        _context.Entry(doctor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DoctorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Doctors
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
    {
      if (_context.Doctors == null)
      {
          return Problem("Entity set 'HealthCareContext.Doctors'  is null.");
      }
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDoctor", new { id = doctor.DoctorId }, doctor);
    }

    // DELETE: api/Doctors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        if (_context.Doctors == null)
        {
            return NotFound();
        }
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DoctorExists(int id)
    {
        return (_context.Doctors?.Any(e => e.DoctorId == id)).GetValueOrDefault();
    }*/
    }
}
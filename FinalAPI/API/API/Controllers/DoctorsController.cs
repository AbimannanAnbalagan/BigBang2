using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Repositories.Doctors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctor _context;

        public DoctorsController(IDoctor context)
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

        [HttpGet("Byname{name}")]
        public async Task<ActionResult<List<Doctor>>> DoctorById(string name)
        {
            try
            {
                return await _context.DoctorById(name);

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

        [HttpPut("{username}")]
        public async Task<ActionResult<List<Doctor>>> PutDoctor(string username, Doctor doctor)
        {
            try
            {
                return await _context.PutDoctor(username, doctor);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}

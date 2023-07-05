using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Repositories.Appointments;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointment _context;

        public AppointmentsController(IAppointment context)
        {
            _context = context;
        }

        [HttpGet ("{name}")]
        public async Task<ActionResult<List<Appointment>>> GetAppointments(string name)
        {
            try
            {
                return await _context.GetAppointments(name);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Appointment>>> PostAppointment(Appointment appointment)
        {
            try
            {
                return await _context.PostAppointment(appointment);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Appointment>>> PutAppointment(int id, Appointment appointment)
        {
            try
            {
                return await _context.PutAppointment(id, appointment);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}

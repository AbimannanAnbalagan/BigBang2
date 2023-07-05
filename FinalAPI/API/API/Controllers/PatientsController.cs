using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Repositories.Patients;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatients _context;

        public PatientsController(IPatients context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Patient>>> getbyname(string name)
        {
            try
            {
                return await _context.getbyname(name);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


    }
}

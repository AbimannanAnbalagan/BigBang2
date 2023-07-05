using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Repositories.Feedbacks;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedback _context;

        public FeedbacksController(IFeedback context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Feedback>>> GetFeedbacks()
        {
            try
            {
                return await _context.GetFeedbacks();

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Feedback>>> PostFeedbacks(Feedback feedback)
        {
            try
            {
                return await _context.PostFeedbacks(feedback);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

    }
}

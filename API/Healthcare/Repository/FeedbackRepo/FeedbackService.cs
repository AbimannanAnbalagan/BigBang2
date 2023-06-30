using Healthcare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Repository.FeedbackRepo
{
  public class FeedbackService : IFeedbackService
  {
    private readonly HealthCareContext _context;

    public FeedbackService(HealthCareContext context)
    {
      _context = context; 
    }

    public async Task<List<Feedback>> GetFeedbacks()
    {
      var result = await _context.Feedbacks.ToListAsync();
      if (result == null)
      {
        throw new Exception("No Feedbacks");
      }
      return result;
    }

    public async Task<List<Feedback>> PostFeedbacks(Feedback feedback)
    {
      await _context.Feedbacks.AddAsync(feedback);
      await _context.SaveChangesAsync();
      return _context.Feedbacks.Where(x=>x.FeedbackId == feedback.FeedbackId).ToList();
    }

  }
}

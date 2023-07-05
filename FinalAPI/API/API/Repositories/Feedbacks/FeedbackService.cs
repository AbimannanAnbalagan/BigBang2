using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Feedbacks
{
    public class FeedbackService : IFeedback
    {
        private readonly BigBang2Context _context;

        public FeedbackService(BigBang2Context context)
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
            return _context.Feedbacks.Where(x => x.FeedbackId == feedback.FeedbackId).ToList();
        }
    }
}

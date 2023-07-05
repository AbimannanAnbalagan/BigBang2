using API.Models;

namespace API.Repositories.Feedbacks
{
    public interface IFeedback
    {
        Task<List<Feedback>> GetFeedbacks();
        Task<List<Feedback>> PostFeedbacks(Feedback feedback);
    }
}

using Healthcare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Repository.FeedbackRepo
{
  public interface IFeedbackService
  {
    Task<List<Feedback>> GetFeedbacks();
    Task<List<Feedback>> PostFeedbacks(Feedback feedback);

  }
}

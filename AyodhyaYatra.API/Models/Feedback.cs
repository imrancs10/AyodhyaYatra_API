using System.ComponentModel.DataAnnotations.Schema;

namespace AyodhyaYatra.API.Models
{
    public class Feedback : BaseModel
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string FeedbackComment { get; set; }
    }
}

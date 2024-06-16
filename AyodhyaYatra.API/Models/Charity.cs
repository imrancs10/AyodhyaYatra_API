namespace AyodhyaYatra.API.Models
{
    public class Charity:BaseModel
    {
        public string CharityName { get; set; }
        public string CharityPurpose { get; set; }
        public string CharityType { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}

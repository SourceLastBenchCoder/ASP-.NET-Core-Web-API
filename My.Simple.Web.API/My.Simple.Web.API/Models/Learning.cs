namespace My.Simple.Web.API.Models
{
    public class Learning
    {
        public int LearningId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}

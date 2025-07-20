namespace Volton.Models
{
    public class NavigationViewModel
    {
        public string PrevAction { get; set; }
        public string NextAction { get; set; }
        public bool IsFormSubmission { get; set; }
        public string NextButtonId { get; set; } = "nextBtn";
    }
}

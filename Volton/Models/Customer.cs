namespace Volton.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Preference { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public object Details { get; set; }

    }
       
    
}

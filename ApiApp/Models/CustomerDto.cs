
namespace ApiApp.Models
{
    public partial class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCategoryName { get; set; }
        public string CityName { get; set; }
        public string PrimaryContact { get; set; } 
        public string PhoneNumber { get; set; }
    }
}

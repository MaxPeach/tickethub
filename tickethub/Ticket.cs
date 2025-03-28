using System.ComponentModel.DataAnnotations;

namespace tickethub
{
    public class Ticket
    {
        [Required(ErrorMessage = "Concert ID is required")]
        public int ConcertId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name should be less than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; set; } = 0;

        [Required(ErrorMessage = "Credit card is required")]
        [CreditCard(ErrorMessage = "Invalid credit card number")]
        public string CreditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration date is required")]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security code is required")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Security code must be 3 digits")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(200, ErrorMessage = "Address is too long")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [MaxLength(100, ErrorMessage = "City name is too long")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required")]
        [MaxLength(100, ErrorMessage = "Province name is too long")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Invalid postal code format")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(100, ErrorMessage = "Country name is too long")]
        public string Country { get; set; } = string.Empty;
    }
}

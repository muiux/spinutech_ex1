using System.ComponentModel.DataAnnotations;

namespace Spinutech_assessment.Models
{
    public class AmountModel
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }
        public string? ConvertedAmount { get; set; }
    }
}

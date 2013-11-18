using System.ComponentModel.DataAnnotations;
using OctoFX.Core.Model;

namespace OctoFX.TradingWebsite.Models
{
    public class DealModel
    {
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
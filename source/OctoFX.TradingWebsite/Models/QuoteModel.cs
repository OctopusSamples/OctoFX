using System.ComponentModel.DataAnnotations;
using OctoFX.Core.Model;

namespace OctoFX.TradingWebsite.Models
{
    public class QuoteModel
    {
        [Required]
        public Currency BuyCurrency { get; set; }
        [Required]
        public Currency SellCurrency { get; set; }
        
        [Required]
        public decimal QuantityToSell { get; set; }
    }
}
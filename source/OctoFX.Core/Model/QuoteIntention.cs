namespace OctoFX.TradingWebsite.Models
{
    public enum QuoteIntention
    {
        /// <summary>
        /// Joe has $1000 USD to sell, and wants to know how much AUD he can get.
        /// </summary>
        HasQuantityToSell,

        /// <summary>
        /// Joe needs $1000 AUD and wants to know how much it will cost him in USD.
        /// </summary>
        WantsToBuy
    }
}
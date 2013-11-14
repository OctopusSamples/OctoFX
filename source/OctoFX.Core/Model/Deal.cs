using System;

namespace OctoFX.Core.Model
{
    public class Deal
    {
        public virtual int Id { get; set; }
        public virtual Account Account { get; set; }
        public virtual BeneficiaryAccount NominatedBeneficiaryAccount { get; set; }
        public virtual Currency BuyCurrency { get; set; }
        public virtual Currency SellCurrency { get; set; }
        public virtual decimal BuyAmount { get; set; }
        public virtual decimal SellAmount { get; set; }
        public virtual DealStatus Status { get; set; }
        public virtual DateTimeOffset EnteredDate { get; set; }
    }
}
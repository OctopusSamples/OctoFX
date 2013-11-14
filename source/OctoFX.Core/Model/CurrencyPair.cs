using System;

namespace OctoFX.Core.Model
{
    public class CurrencyPair : IEquatable<CurrencyPair>
    {
        private readonly Currency sell;
        private readonly Currency buy;

        public CurrencyPair(Currency sell, Currency buy)
        {
            if (sell == null) throw new ArgumentNullException("sell");
            if (buy == null) throw new ArgumentNullException("buy");
            if (sell == buy) throw new ArgumentException(string.Format("Cannot create a currency pair of: {0}/{1} because both currencies are the same", sell, buy));

            this.sell = sell;
            this.buy = buy;
        }

        public Currency Sell
        {
            get { return sell; }
        }

        public Currency Buy
        {
            get { return buy; }
        }

        public bool Equals(CurrencyPair other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(sell, other.sell) && Equals(buy, other.buy);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CurrencyPair) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((sell != null ? sell.GetHashCode() : 0)*397) ^ (buy != null ? buy.GetHashCode() : 0);
            }
        }

        public static bool operator ==(CurrencyPair left, CurrencyPair right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CurrencyPair left, CurrencyPair right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", sell, buy);
        }

        public static CurrencyPair Parse(string pair)
        {
            CurrencyPair result;
            if (!TryParse(pair, out result))
            {
                throw new FormatException("Could not parse currency pair: " + pair);
            }

            return result;
        }

        public static bool TryParse(string pair, out CurrencyPair result)
        {
            result = null;
            if (string.IsNullOrWhiteSpace(pair))
                return false;

            var split = pair.Split('/');
            if (split.Length != 2)
                return false;

            Currency a;
            Currency b;

            if (!Currency.TryParse(split[0], out a)
                || !Currency.TryParse(split[1], out b))
                return false;

            result = new CurrencyPair(a, b);
            return true;
        }
    }
}
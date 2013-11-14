using System;

namespace OctoFX.Core.Model
{
    public class CurrencyPair : IEquatable<CurrencyPair>
    {
        private readonly Currency first;
        private readonly Currency second;

        public CurrencyPair(Currency first, Currency second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (first == second) throw new ArgumentException(string.Format("Cannot create a currency pair of: {0}/{1} because both currencies are the same", first, second));

            var items = new[] {first, second};
            Array.Sort(items);

            this.first = items[0];
            this.second = items[1];
        }

        public Currency First
        {
            get { return first; }
        }

        public Currency Second
        {
            get { return second; }
        }

        public bool Equals(CurrencyPair other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(first, other.first) && Equals(second, other.second);
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
                return ((first != null ? first.GetHashCode() : 0)*397) ^ (second != null ? second.GetHashCode() : 0);
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
            return string.Format("{0}/{1}", first, second);
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OctoFX.Core.Model
{
    public class Currency : IEquatable<Currency>, IComparable<Currency>, IComparable
    {
        static readonly IDictionary<string, Currency> currenciesByCode = new Dictionary<string, Currency>(StringComparer.OrdinalIgnoreCase);
        private readonly string isoCurrencyCode;
        private readonly string displayName;
        private static readonly Currency aud = new Currency("AUD", "Australian Dollar");
        private static readonly Currency eur = new Currency("EUR", "Euro");
        private static readonly Currency gbp = new Currency("GBP", "British Pound");
        private static readonly Currency usd = new Currency("USD", "United States Dollar");
        private static readonly ReadOnlyCollection<Currency> allSupportedCurrencies; 

        static Currency()
        {
            var currencies = new List<Currency>();
            currencies.Add(aud);
            currencies.Add(eur);
            currencies.Add(gbp);
            currencies.Add(usd);

            foreach (var currency in currencies)
            {
                currenciesByCode[currency.IsoCurrencyCode] = currency;
            }

            allSupportedCurrencies = currencies.AsReadOnly();
        }

        Currency(string isoCurrencyCode, string displayName)
        {
            this.isoCurrencyCode = isoCurrencyCode;
            this.displayName = displayName;
        }

        public string IsoCurrencyCode
        {
            get { return isoCurrencyCode; }
        }

        public string DisplayName
        {
            get { return displayName; }
        }

        public static Currency Aud
        {
            get { return aud; }
        }

        public static Currency Eur
        {
            get { return eur; }
        }

        public static Currency Gbp
        {
            get { return gbp; }
        }

        public static Currency Usd
        {
            get { return usd; }
        }

        public static ReadOnlyCollection<Currency> AllSupportedCurrencies
        {
            get { return allSupportedCurrencies; }
        }

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(isoCurrencyCode, other.isoCurrencyCode) && string.Equals(displayName, other.displayName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Currency) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((isoCurrencyCode != null ? isoCurrencyCode.GetHashCode() : 0)*397) ^ (displayName != null ? displayName.GetHashCode() : 0);
            }
        }

        public int CompareTo(object obj)
        {
            return CompareTo((Currency) obj);
        }

        public static bool operator ==(Currency left, Currency right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Currency left, Currency right)
        {
            return !Equals(left, right);
        }

        public static Currency FromIsoCode(string currencyCode)
        {
            return Parse(currencyCode);
        }
        
        public static Currency Parse(string currencyCode)
        {
            Currency parsed;
            if (!TryParse(currencyCode, out parsed))
            {
                throw new NotSupportedException(string.Format("The currency code \"{0}\" is not supported.", currencyCode));
            }

            return parsed;
        }

        public static implicit operator Currency(string code)
        {
            if (code == null)
                return null;

            return FromIsoCode(code);
        }

        public static bool TryParse(string code, out Currency currency)
        {
            currency = null;
            return !string.IsNullOrWhiteSpace(code) 
                   && currenciesByCode.TryGetValue(code, out currency);
        } 

        public static implicit operator string(Currency currency)
        {
            return currency.ToString();
        }

        public int CompareTo(Currency other)
        {
            return isoCurrencyCode.CompareTo(other);
        }

        public override string ToString()
        {
            return isoCurrencyCode;
        }
    }
}
using System;
using System.Data;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace OctoFX.Core.Model
{
    public class CurrencyPairUserType : IUserType
    {
        bool IUserType.Equals(object x, object y)
        {
            return (CurrencyPair)x == (CurrencyPair)y;
        }

        public int GetHashCode(object x)
        {
            return ((CurrencyPair)x).GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var value = (string)NHibernateUtil.String.NullSafeGet(rs, names[0]);
            return CurrencyPair.Parse(value);
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                var currency = (CurrencyPair)value;
                ((IDataParameter)cmd.Parameters[index]).Value = currency.ToString();
            }
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public SqlType[] SqlTypes
        {
            get { return new SqlType[] { SqlTypeFactory.GetString(7) }; }
        }

        public Type ReturnedType { get { return typeof(CurrencyPair); } }
        public bool IsMutable { get { return true; } }
    }
}
using System;
using System.Data;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace OctoFX.Core.Model
{
    public class CurrencyUserType : IUserType
    {
        bool IUserType.Equals(object x, object y)
        {
            return (Currency) x == (Currency) y;
        }

        public int GetHashCode(object x)
        {
            return ((Currency) x).GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var value = (string)NHibernateUtil.String.NullSafeGet(rs, names[0]);
            return Currency.Parse(value);
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                var currency = (Currency)value;
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
            get { return new SqlType[] { SqlTypeFactory.GetString(3) }; }
        }

        public Type ReturnedType { get { return typeof (Currency); } }
        public bool IsMutable { get { return true; } }
    }
}
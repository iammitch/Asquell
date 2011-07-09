using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asquell.Objects
{
    class NumericObj
    {
        private AsquellObj baseObj;
        public NumericObj(double number) : this(new AsquellObj(number)) { }
        public NumericObj(AsquellObj obj)
        {
            baseObj = obj;
        }
        public double Value
        {
            get { return (double)baseObj.Value; }
        }
        public static NumericObj operator +(NumericObj a, NumericObj b)
        {
            return new NumericObj((double)a.baseObj.Value + (double)b.baseObj.Value);
        }
        public static NumericObj operator -(NumericObj a, NumericObj b)
        {
            return new NumericObj((double)a.baseObj.Value - (double)b.baseObj.Value);
        }
        public static NumericObj operator *(NumericObj a, NumericObj b)
        {
            return new NumericObj((double)a.baseObj.Value * (double)b.baseObj.Value);
        }
        public static NumericObj operator /(NumericObj a, NumericObj b)
        {
            return new NumericObj((double)a.baseObj.Value / (double)b.baseObj.Value);
        }
        public static NumericObj operator %(NumericObj a, NumericObj b)
        {
            return new NumericObj((double)a.baseObj.Value % (double)b.baseObj.Value);
        }
        public static NumericObj operator ^(NumericObj a, NumericObj b)
        {
            return new NumericObj(Math.Pow((double)a.baseObj.Value,(double)b.baseObj.Value));
        }
        public static bool operator <(NumericObj a, NumericObj b)
        {
            return ((double)a.baseObj.Value < (double)b.baseObj.Value);
        }
        public static bool operator >(NumericObj a, NumericObj b)
        {
            return ((double)a.baseObj.Value > (double)b.baseObj.Value);
        }
        public static bool operator <=(NumericObj a, NumericObj b)
        {
            return ((double)a.baseObj.Value <= (double)b.baseObj.Value);
        }
        public static bool operator >=(NumericObj a, NumericObj b)
        {
            return ((double)a.baseObj.Value >= (double)b.baseObj.Value);
        }
        public static bool operator ==(NumericObj a, NumericObj b)
        {
            return ((double)a.baseObj.Value == (double)b.baseObj.Value);
        }
        public static bool operator !=(NumericObj a, NumericObj b)
        {
            return ((double)a.baseObj.Value != (double)b.baseObj.Value);
        }
        public static NumericObj operator ++(NumericObj a)
        {
            return new NumericObj((double)a.baseObj.Value + 1);
        }
        public static NumericObj operator --(NumericObj a)
        {
            return new NumericObj((double)a.baseObj.Value - 1);
        }
        public override int GetHashCode()
        {
            return baseObj.Value.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return baseObj.Value.Equals(obj);
        }
    }
}

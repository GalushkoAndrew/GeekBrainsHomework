using System;
using System.Text;

namespace GeekBrains.Learn.Numbers.Rational
{

    /// <summary>
    /// Рациональное число
    /// </summary>
    internal sealed class RationalNumber
    {
        private int _divisible;
        private int _divider;

        /// <summary>
        /// ctor
        /// </summary>
        public RationalNumber() : this(0, 1)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public RationalNumber(int divisible) : this(divisible, 1)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public RationalNumber(int divisible, int divider)
        {
            Divisible = divisible;
            Divider = divider;
        }

        /// <summary>
        /// Делимое
        /// </summary>
        public int Divisible
        {
            get { return _divisible; }
            set { _divisible = value; }
        }

        /// <summary>
        /// Делитель
        /// </summary>
        public int Divider
        {
            get
            {
                return _divider;
            }

            set
            {
                _divider = value == 0 ? 1 : value;
            }
        }

        public static implicit operator RationalNumber(int v)
        {
            return new RationalNumber(v);
        }

        public static implicit operator int(RationalNumber v)
        {
            return v.Divisible / v.Divider;
        }

        public static implicit operator RationalNumber(float v)
        {
            return new RationalNumber((int)Math.Truncate(v * 100), 100);
        }

        public static implicit operator float(RationalNumber v)
        {
            if (v == null)
            {
                return 0;
            }

            return (float)v.Divisible / v.Divider;
        }

        public static bool operator ==(RationalNumber r1, RationalNumber r2)
        {
            if (IsHasNull(r1, r2))
            {
                return false;
            }

            return (float)r1 == (float)r2;
        }

        public static bool operator !=(RationalNumber r1, RationalNumber r2)
        {
            return !(r1 == r2);
        }

        public static bool operator >(RationalNumber r1, RationalNumber r2)
        {
            return (float)r1 > (float)r2;
        }

        public static bool operator <(RationalNumber r1, RationalNumber r2)
        {
            return (float)r1 < (float)r2;
        }

        public static bool operator >=(RationalNumber r1, RationalNumber r2)
        {
            return (float)r1 >= (float)r2;
        }

        public static bool operator <=(RationalNumber r1, RationalNumber r2)
        {
            return (float)r1 <= (float)r2;
        }

        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            if (IsHasNull(r1, r2))
            {
                return null;
            }

            if (r1.Divider == r2.Divider)
            {
                return new RationalNumber(r1.Divisible + r2.Divisible, r1.Divider);
            }

            // HACK: упростить общий делитель
            return new RationalNumber((r1.Divisible * r2.Divider) + (r2.Divisible * r1.Divider), r1.Divider * r2.Divider);
        }

        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            if (IsHasNull(r1, r2))
            {
                return null;
            }

            if (r1.Divider == r2.Divider)
            {
                return new RationalNumber(r1.Divisible - r2.Divisible, r1.Divider);
            }

            // HACK: упростить общий делитель
            return new RationalNumber((r1.Divisible * r2.Divider) - (r2.Divisible * r1.Divider), r1.Divider * r2.Divider);
        }

        public static RationalNumber operator ++(RationalNumber r)
        {
            if (IsHasNull(r))
            {
                return null;
            }

            r.Divisible = r.Divisible + r.Divider;
            return r;
        }

        public static RationalNumber operator --(RationalNumber r)
        {
            if (IsHasNull(r))
            {
                return null;
            }

            r.Divisible = r.Divisible - r.Divider;
            return r;
        }

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            if (IsHasNull(r1, r2))
            {
                return null;
            }

            // HACK: упростить общий делитель
            return new RationalNumber(r1.Divisible * r2.Divisible, r1.Divider * r2.Divider);
        }

        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            if (IsHasNull(r1, r2))
            {
                return null;
            }

            // HACK: упростить общий делитель
            return new RationalNumber(r1.Divisible * r2.Divider, r1.Divider * r2.Divisible);
        }

        public static RationalNumber operator %(RationalNumber r1, RationalNumber r2)
        {
            if (IsHasNull(r1, r2))
            {
                return null;
            }

            // HACK: упростить общий делитель
            return new RationalNumber((r1.Divisible * r2.Divider) % (r2.Divisible * r1.Divider), r1.Divider * r2.Divider);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            return this == (RationalNumber)obj;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return true switch
            {
                true when Divider == 1 => ToStringWhenDividerIsOne(),
                true when Divisible == 0 => ToStringWhenDivisibleIsZero(),
                _ => ToStringDefault(),
            };
        }

        /// <summary>
        /// Returns the integer part of a rational number
        /// </summary>
        public int ToInt()
        {
            return this;
        }

        /// <summary>
        /// Returns the float value of a rational number
        /// </summary>
        public float ToFloat()
        {
            return this;
        }

        private static bool IsHasNull(RationalNumber r1, RationalNumber r2)
        {
            return IsHasNull(r1) || IsHasNull(r2);
        }

        private static bool IsHasNull(RationalNumber r)
        {
            return r is null;
        }

        private string ToStringWhenDividerIsOne()
        {
            return Divisible.ToString();
        }

        private string ToStringWhenDivisibleIsZero()
        {
            return "0";
        }

        private string ToStringDefault()
        {
            return new StringBuilder().Append(Divisible).Append('/').Append(Divider).ToString();
        }
    }
}

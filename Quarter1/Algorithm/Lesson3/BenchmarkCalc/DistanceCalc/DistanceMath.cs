using GeekBrains.Learn.DistanceCalc.Model;
using System;

namespace GeekBrains.Learn.DistanceCalc
{
    public class DistanceMath
    {
        public float CalcClassSqrt(PointClass point1, PointClass point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public float CalcStuctFloatSqrt(PointStructFloat point1, PointStructFloat point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public double CalcStuctDoubleSqrt(PointStructDouble point1, PointStructDouble point2)
        {
            double x = point1.X - point2.X;
            double y = point1.Y - point2.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public float CalcStuctFloatNoSqrt(PointStructFloat point1, PointStructFloat point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;
            return Fsrt((x * x) + (y * y));
        }

        public static float Fsrt(float z)
        {
            if (z == 0) return 0;
            FloatIntUnion u;
            u.i = 0;
            u.f = z;
            u.i -= 1 << 23; /* Subtract 2^m. */
            u.i >>= 1; /* Divide by 2. */
            u.i += 1 << 29; /* Add ((b + 1) / 2) * 2^m. */
            return u.f;
        }
    }

}

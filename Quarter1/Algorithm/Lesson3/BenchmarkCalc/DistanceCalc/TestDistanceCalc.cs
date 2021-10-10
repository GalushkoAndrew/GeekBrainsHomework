using GeekBrains.Learn.DistanceCalc.Model;
using System;

namespace GeekBrains.Learn.DistanceCalc
{
    public class TestDistanceCalc
    {
        readonly double xd1 = 1.235;
        readonly double yd1 = 2.564;
        readonly double xd2 = 7.852;
        readonly double yd2 = 12.268;
        readonly float xf1 = 1.235F;
        readonly float yf1 = 2.564F;
        readonly float xf2 = 7.852F;
        readonly float yf2 = 12.268F;

        public void TestCalc()
        {
            DistanceMath distanceMath = new();


            PointClass pc1 = GetPointClass1();
            PointClass pc2 = GetPointClass2();

            PointStructFloat psf1 = GetPointStructFloat1();
            PointStructFloat psf2 = GetPointStructFloat2();

            PointStructDouble psd1 = GetPointStructDouble1();
            PointStructDouble psd2 = GetPointStructDouble2();

            Console.WriteLine(distanceMath.CalcClassSqrt(pc1, pc2));
            Console.WriteLine(distanceMath.CalcStuctFloatSqrt(psf1, psf2));
            Console.WriteLine(distanceMath.CalcStuctDoubleSqrt(psd1, psd2));
            Console.WriteLine(distanceMath.CalcStuctFloatNoSqrt(psf1, psf2));
        }

        public PointClass GetPointClass1()
        {
            return new() { X = xf1, Y = yf1 };
        }

        public PointClass GetPointClass2()
        {
            return new() { X = xf2, Y = yf2 };
        }

        public PointStructFloat GetPointStructFloat1()
        {
            return new() { X = xf1, Y = yf1 };
        }

        public PointStructFloat GetPointStructFloat2()
        {
            return new() { X = xf2, Y = yf2 };
        }

        public PointStructDouble GetPointStructDouble1()
        {
            return new() { X = xd1, Y = yd1 };
        }

        public PointStructDouble GetPointStructDouble2()
        {
            return new() { X = xd2, Y = yd2 };
        }
    }
}

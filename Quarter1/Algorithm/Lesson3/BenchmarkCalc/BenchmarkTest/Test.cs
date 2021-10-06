using GeekBrains.Learn.DistanceCalc.Model;
using GeekBrains.Learn.DistanceCalc;
using BenchmarkDotNet.Attributes;

namespace GeekBrains.Learn.BenchmarkTest
{
    [RankColumn]
    public class Test
    {
        DistanceMath distanceMath;

        PointClass pc1;
        PointClass pc2;

        PointStructFloat psf1;
        PointStructFloat psf2;

        PointStructDouble psd1;
        PointStructDouble psd2;

        public Test()
        {
            distanceMath = new();
            TestDistanceCalc buildInputObjects = new();

            pc1 = buildInputObjects.GetPointClass1();
            pc2 = buildInputObjects.GetPointClass2();

            psf1 = buildInputObjects.GetPointStructFloat1();
            psf2 = buildInputObjects.GetPointStructFloat2();

            psd1 = buildInputObjects.GetPointStructDouble1();
            psd2 = buildInputObjects.GetPointStructDouble2();
        }

        [Benchmark]
        public void CalcClassSqrt()
        {
            distanceMath.CalcClassSqrt(pc1, pc2);
        }

        [Benchmark]
        public void CalcStuctFloatSqrt()
        {
            distanceMath.CalcStuctFloatSqrt(psf1, psf2);
        }

        [Benchmark]
        public void CalcStuctDoubleSqrt()
        {
            distanceMath.CalcStuctDoubleSqrt(psd1, psd2);
        }

        [Benchmark]
        public void CalcStuctFloatNoSqrt()
        {
            distanceMath.CalcStuctFloatNoSqrt(psf1, psf2);
        }
    }
}

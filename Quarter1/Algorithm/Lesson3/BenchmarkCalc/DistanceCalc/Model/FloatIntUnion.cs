using System.Runtime.InteropServices;

namespace GeekBrains.Learn.DistanceCalc
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct FloatIntUnion
    {
        [FieldOffset(0)]
        public int i;

        [FieldOffset(0)]
        public float f;
    }

}

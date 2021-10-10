using System.Collections.Generic;
using System.Linq;

namespace GeekBrains.Learn.HashSearch
{
    public class MathSearch
    {
        public bool SearchArray(string[] array, string value)
        {
            return array.Any(x => x.Equals(value));
        }

        public bool SearchHashSet(HashSet<string> hashSet, string value)
        {
            return hashSet.Contains(value);
        }
    }
}

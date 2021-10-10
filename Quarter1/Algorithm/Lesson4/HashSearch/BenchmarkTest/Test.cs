using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using GeekBrains.Learn.HashSearch;

namespace GeekBrains.Learn.BenchmarkTest
{
    public class Test
    {
        readonly int size = 10000;
        string[] arrString;
        HashSet<string> hashSet;
        MathSearch mathSearch;
        string errorString;
        string trueString;

        public Test()
        {
            GenerateData();
        }

        private void GenerateData()
        {
            arrString = new string[size];
            hashSet = new();
            mathSearch = new();

            for (int i = 0; i < size; i++)
            {
                arrString[i] = Guid.NewGuid().ToString();
                hashSet.Add(arrString[i]);
            }

            errorString = "qwertyuiop[]asdfghjk123";
            trueString = arrString[5000];
        }

        [Benchmark]
        public bool TestArrayTrue()
        {
            return mathSearch.SearchArray(arrString, trueString);
        }

        [Benchmark]
        public bool TestHashTrue()
        {
            return mathSearch.SearchHashSet(hashSet, trueString);
        }

        [Benchmark]
        public bool TestArrayFalse()
        {
            return mathSearch.SearchArray(arrString, errorString);
        }

        [Benchmark]
        public bool TestHashFalse()
        {
            return mathSearch.SearchHashSet(hashSet, errorString);
        }

    }
}

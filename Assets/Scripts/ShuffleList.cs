using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Threading;

namespace myShuffleNamespace
{

    public static class ShuffleList
    {

        public static void ShuffleL<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                //int k = rng.Next(n + 1);
                var k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}

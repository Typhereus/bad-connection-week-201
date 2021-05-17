using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleList : MonoBehaviour
{
    public static void ShuffleTheList<T>(List<T> list)
    {
        for (int t = 0; t < list.Count; t++)
        {
            var tmp = list[t];
            int r = RandomStaticSystem.rng.Next(t, list.Count);
            list[t] = list[r];
            list[r] = tmp;
        }
    }

    //Static number generator guarrantees that there will
    //will be no repitition.
    private class RandomStaticSystem
    {
        public static System.Random rng;

        static RandomStaticSystem()
        {
            rng = new System.Random();
        }
    }
}
